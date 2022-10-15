﻿using DevExpress.XtraEditors;
using DevExpress.XtraWaitForm;
using HouseholdManager.DAO;
using HouseholdManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HouseholdManager.BUS
{
    public class PersonBUS
    {
        private PersonBUS() { }

        private static readonly PersonBUS instance = new PersonBUS();

        public static PersonBUS Instance => instance;

        public List<Person> GetListPerson(string columnOrder = "ID")
        {
            List<Person> listPerson = new List<Person>();

            DataTable data = PersonDAO.Instance.GetListPerson(columnOrder);

            foreach (DataRow row in data.Rows)
            {
                listPerson.Add(new Person(row));
            }

            return listPerson;
        }

        /// <summary>
        /// Lấy nhân khẩu mới được tạo gần nhất.
        /// </summary>
        /// <returns></returns>
        public Person GetNewPerson()
        {
            DataTable data = PersonDAO.Instance.GetNewPerson();

            if (data.Rows.Count > 0) return new Person(data.Rows[0]);

            return null;
        }

        public Person GetPersonByID(int id)
        {
            DataTable data = PersonDAO.Instance.GetPersonByID(id);

            if (data.Rows.Count > 0) return new Person(data.Rows[0]);

            return null;
        }

        public Person InsertPerson(string name, int gender, string dateOfBirth, string cmnd, string address, int householdID, int relation)
        {
            if (!name.IsVietnamese() || !address.IsVietnamese()) 
            {
                MessageBox.Show("Họ tên và quê quán chỉ được sử dụng ký tự Latin.\nGiữa các từ chỉ có 1 dấu cách.\nTrong 1 từ có nhiều nhất 1 dấu nháy đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }

            if (!dateOfBirth.IsDate())
            {
                MessageBox.Show("Ngày tháng phải có dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }

            if (!cmnd.IsNumber(9) && !cmnd.IsNumber(12))
            {
                MessageBox.Show("Số chứng minh nhân dân phải là dãy 9 hoặc 12 chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }

            var data = PersonDAO.Instance.InsertPerson(name, gender, dateOfBirth.ToDate(), cmnd, address, householdID, relation);

            if (data.Rows.Count > 0) return new Person(data.Rows[0]);

            return null;
        }

        public bool DeletePerson(int id)
        {
            return PersonDAO.Instance.DeletePerson(id);
        }

        public bool UpdatePerson(int id, string name, int gender, string dateOfBirth, string cmnd, string address, int householdID, int relation)
        {
            if (!name.IsVietnamese() || !address.IsVietnamese())
            {
                MessageBox.Show("Họ tên và quê quán chỉ được sử dụng ký tự Latin.\nGiữa các từ chỉ có 1 dấu cách.\nTrong 1 từ có nhiều nhất 1 dấu nháy đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            if (!dateOfBirth.IsDate())
            {
                MessageBox.Show("Ngày tháng phải có dạng dd/MM/yyyy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            if (!cmnd.IsNumber(9) && !cmnd.IsNumber(12))
            {
                MessageBox.Show("Số chứng minh nhân dân phải là dãy 9 hoặc 12 chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return PersonDAO.Instance.UpdatePerson(id, name, gender, dateOfBirth.ToDate(), cmnd, address, householdID, relation);

        }

        public bool LoadFileExcel(string fileName, ProgressBarControl bar, ProgressPanel panel)
        {

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Open(fileName);

            Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.Worksheets[1];

            Microsoft.Office.Interop.Excel.Range range = worksheet.UsedRange;

            //tính số hàng cần lấy trong file excel
            int rowCount = range.Rows.Count;

            string query = "";

            try
            {
                for (int i = 1; i <= rowCount; i++)
                {
                    if (worksheet.Cells[i, 3] != null && worksheet.Cells[i, 3].Value2 != null)
                    {
                        string name = worksheet.Cells[i, 3].Value2;
                        name = name.ToSingleSpace();
                        name = name.IsVietnamese() ? name : throw new Exception($"Họ tên không phù hợp Cells[{i}, 3].");
                        name = name.Replace("'", "''");

                        string genderStr = worksheet.Cells[i, 4].Value2;
                        int genderInt = genderStr.ToGender() ?? throw new Exception($"Giới tính không phù hợp Cells[{i}, 4].");

                        DateTime date = DateTime.FromOADate(worksheet.Cells[i, 5].Value2);
                        string dateOfBirth = date.ToString("dd/MM/yyyy").IsDate() ? date.ToString("dd/MM/yyyy").ToDate() : throw new Exception($"Ngày sinh không phù hợp Cells[{i}, 5].");

                        string cmnd = Convert.ToString(worksheet.Cells[i, 6].Value2);
                        cmnd = cmnd.ToSingleSpace();
                        cmnd = cmnd.IsNumber(9) || cmnd.IsNumber(12) ? cmnd : throw new Exception($"CMND không phù hợp Cells[{i}, 6].");

                        string address = worksheet.Cells[i, 7].Value2;
                        address = address.ToSingleSpace();
                        address = address.IsVietnamese()? address : throw new Exception($"Địa chỉ không phù hợp Cells[{i}, 7].");
                        address = address.Replace("'", "''");

                        query += $"INSERT INTO [Person] ( [Name], [Gender], [DateOfBirth], [CMND], [Address]) VALUES ( '{name}', {genderInt}, '{dateOfBirth}', '{cmnd}', '{address}');\n";

                    }
                    //Cập nhật thanh progress trên form
                    bar.Position = i * 100 / rowCount;

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //Có lỗi sẽ return ngay, không insert vào database
                return false;
            }
            finally
            {
                //return ngay trong try/catch cần dùng finally để luôn close file
                workbook.Close();
                excel.Quit();
            }

            panel.WaitAnimationType = DevExpress.Utils.Animation.WaitingAnimatorType.Bar;
            panel.ShowDescription = true;

            if (DataProvider.Instance.ExecuteNonQuery(query) > 0) return true;

            return false;
        }

        public bool CreateFileExcel(string fileName, List<Person> list, ProgressBarControl bar)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add();

            Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.Worksheets[1];

            worksheet.Name = "Danh sách nhân khẩu";
            var index = 0;
            //var result = false;
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    //Gán giá trị cho index để hiển thị ra message box nếu có exception
                    index = i;

                    worksheet.Cells[i + 1, 1] = i + 1;
                    worksheet.Cells[i + 1, 2] = list[i].ID;
                    worksheet.Cells[i + 1, 3] = list[i].Name;
                    worksheet.Cells[i + 1, 4] = list[i].Gender.ToStringDescription();
                    worksheet.Cells[i + 1, 5] = list[i].DateOfBirth;
                    worksheet.Cells[i + 1, 6] = "'" + list[i].Cmnd; //Thêm dấu ' để không bị Excel cắt bớt số 0 ở đầu
                    worksheet.Cells[i + 1, 7] = list[i].Address;
                    worksheet.Cells[i + 1, 8] = list[i].HouseholdID;
                    worksheet.Cells[i + 1, 9] = list[i].Relation.ToStringDescription();

                    bar.Position = i * 100 / list.Count;
                    
                }
                //result = true;
                return true;
            }
            catch (Exception e)
            {
                //result = false;

                MessageBox.Show(e.Message + $"\n\nLỗi...\n" +
                    $"ID: {list[index].ID}\n" +
                    $"Họ tên: {list[index].Name}\n" +
                    $"Giới tính: {list[index].Gender}\n" +
                    $"Ngày sinh: {list[index].DateOfBirth}\n" +
                    $"CMND: {list[index].Cmnd}\n" +
                    $"Quê quán: {list[index].Address}\n" +
                    $"ID hộ khẩu: {list[index].HouseholdID}\n" +
                    $"Quan hệ: {list[index].Relation}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                //return ngay trong try/catch cần dùng finally để luôn close file
                workbook.SaveAs(fileName);
                workbook.Close();
                excel.Quit();
            }

            //return result;
        }
    }
}
