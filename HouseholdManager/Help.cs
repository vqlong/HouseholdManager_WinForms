using HouseholdManager.GUI;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HouseholdManager
{
    public static class Help
    {
        /// <summary>
        /// Tìm input trong mỗi property của các phần tử trong source.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="input"></param>
        /// <returns>1 List mà các phần tử của nó có 1 property chứa input.</returns>
        public static List<T> Search<T>(List<T> source, string input)
        {
            if (string.IsNullOrEmpty(input)) return source;

            //Lấy ra danh sách các property của T
            var properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);

            //Clone lại source để vừa duyệt vừa sửa
            var output = new List<T>(source);

            //chuyển sang dạng chữ thường không dấu
            input = input.ToLower().ToUnsigned();

            //Nếu item nào có  1 thuộc tính mà giá trị của nó bao gồm giá trị tìm kiếm sẽ được giữ lại
            //Ngược lại, xoá khổi list
            foreach (T item in source)
            {
                var isContained = false;

                foreach (var property in properties)
                {
                    if ((property.PropertyType.IsGenericType || property.PropertyType.IsClass) && property.PropertyType != typeof(string)) continue;

                    if (property.GetValue(item).ToString().ToUnsigned().ToLower().Contains(input))
                    {
                        isContained = true;

                        break;
                    }
                }

                if (!isContained) output.Remove(item);
            }

            //List trả về chỉ gồm các item chứa giá trị tìm kiếm
            return output;  
        }

        /// <summary>
        /// Phân trang cho list, lấy về trang thứ pageNumber với mỗi trang có số hàng là pageSize.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static List<T> GetPage<T>(List<T> list, int pageNumber = 1, int pageSize = 40)
        {
            if (list == null || list.Count <= 0 || pageSize == 0 || pageNumber <= 0) return null;

            //Nếu chọn page cuối
            if (pageNumber == GetTotalPages(list, pageSize)) 
                return list.GetRange((pageNumber - 1) * pageSize, list.Count % pageSize);

            return list.GetRange((pageNumber - 1)*pageSize, pageSize);
        }

        /// <summary>
        /// Lấy tổng số trang của list với mỗi trang có số hàng là pageSize.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static int GetTotalPages<T>(List<T> list, int pageSize = 40)
        {
            if (list == null || list.Count <= 0 || pageSize == 0) return 0;

            int total = list.Count / pageSize;

            if (list.Count % pageSize != 0) total++;

            return total;
        }

        /// <summary>
        /// Chuyển chuỗi sang dạng không dấu.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToUnsigned(string input)
        {
            string signed = "ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ";
            string unsigned = "aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYY";

            for (int i = 0; i < input.Length; i++)
            {
                if (signed.Contains(input[i]))
                    input = input.Replace(input[i], unsigned[signed.IndexOf(input[i])]);
            }

            return input;
        }       

        /// <summary>
        /// Thay thế MessageBox, đặt giá trị cho text3, 2, 1 để hiện nút tương ứng.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="text3"></param>
        /// <param name="text2"></param>
        /// <param name="text1"></param>
        /// <returns>
        /// <br>1 - Nút thứ 1 được nhấn.</br>
        /// <br>2 - Nút thứ 2 được nhấn.</br>
        /// <br>3 - Nút thứ 3 được nhấn.</br>
        /// </returns>
        public static int DialogBox(string text, string caption, string text3 = "Huỷ", string text2 = null, string text1 = null)
        {
            fDialogBox dialog = new fDialogBox(text, caption, text3, text2, text1);

            var result = dialog.ShowDialog();

            if (result == DialogResult.Yes) return 1;
            if (result == DialogResult.No) return 2;
            return 3;

        }

        /// <summary>
        /// Set font cho HeaderCell của các DataGridView.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="font"></param>
        public static void SetHeaderFont(List<DataGridView> list, Font font)
        {
            if(list.Count > 0)
            {
                foreach (var view in list)
                {
                    if(view.Columns.Count > 0)
                    {
                        foreach (DataGridViewColumn column in view.Columns)
                        {
                            column.HeaderCell.Style.Font = font;
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Set font cho các hàng của các DataGridView.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="font"></param>
        public static void SetRowFont(List<DataGridView> list, Font font)
        {
            if (list.Count > 0)
            {
                foreach (var view in list)
                {
                    view.RowsDefaultCellStyle.Font = font;
                }
            }
                
        }

        public static void SetControlFont(List<Control> list, Font font)
        {
            if (list.Count > 0)
            {
                foreach (var control in list)
                {
                    control.Font = font;
                }
            }

        }

        public static void SetLabelFont(List<Label> list , Font font)
        {
            if (list.Count > 0)
            {
                foreach (var label in list)
                {
                    label.Font = font;
                }
            }
        }

        public static void SetTextColor(List<object> list, Color color)
        {
            if (list.Count > 0)
            {
                foreach (dynamic item in list)
                {
                    item.ForeColor = color;
                }
            }

        }

        public static void SetTextColorZ(List<Control> list, Color color)
        {
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    item.ForeColor = color;
                }
            }

        }

        /// <summary>
        /// Dựa theo 1 Dictionary&lt;string, bool&gt;  để cài đặt Enabled = true/false cho các control trong list.
        /// </summary>
        public static void SetPrivilege(Dictionary<string, bool> privilege, List<Control> listControl)
        {
            foreach (Control control in listControl)
            {
                if (privilege.Count > 0)
                {
                    var key = control.Name + "@" + control.Text;

                    if (privilege.ContainsKey(key))
                        control.Enabled = privilege[key];
                    else
                        control.Enabled = false;
                }
                else
                {
                    control.Enabled = false;
                }
            }
        }
    }

    public static class Extension
    {
        /// <summary>
        /// Kiểm tra 1 string có phù hợp các tiêu chuẩn:
        /// <br>1. Chỉ sử dụng ký tự Latin.</br>
        /// <br>2. Giữa các từ chỉ có 1 dấu cách.</br>
        /// <br>3. Trong 1 từ có nhiều nhất 1 dấu nháy đơn.</br>
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsVietnamese(this string text)
        {
            if (string.IsNullOrEmpty(text)) return false;

            string vnChar = @"aAàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆfFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTuUùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ\d";

            string pattern = $@"^(([{vnChar}]+)|([{vnChar}]+'?[{vnChar}]+))((\u0020[{vnChar}]+)|(\u0020[{vnChar}]+'?[{vnChar}]+))*$";

            //RegexOptions.ECMAScript: \d => [0-9]
            var match = Regex.Match(text, pattern, RegexOptions.ECMAScript);

            return match.Value.Equals(text);

        }

        /// <summary>
        /// Kiểm tra 1 string có phù hợp các tiêu chuẩn:
        /// <br>1. Chỉ sử dụng ký tự Latin.</br>
        /// <br>2. Giữa các từ chỉ có 1 dấu cách.</br>
        /// <br>3. Trong 1 từ có nhiều nhất 1 dấu nháy đơn.</br>
        /// <br>4. Chiều dài tối đa cho trước.</br>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static bool IsVietnamese(this string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text)) return false;

            string vnChar = @"aAàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆfFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTuUùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ\d";

            string pattern = $@"^(([{vnChar}]+)|([{vnChar}]+'?[{vnChar}]+))((\u0020[{vnChar}]+)|(\u0020[{vnChar}]+'?[{vnChar}]+))*$";

            //RegexOptions.ECMAScript: \d => [0-9]
            var match = Regex.Match(text, pattern, RegexOptions.ECMAScript);

            return match.Value.Equals(text) && text.Length <= 50;

        }

        /// <summary>
        /// Kiểm tra 1 string có phải là 1 dãy các chữ số.
        /// </summary>
        /// <param name="textNumber"></param>
        /// <returns></returns>
        public static bool IsNumber(this string textNumber)
        {
            if (string.IsNullOrEmpty(textNumber)) return false;

            var match = Regex.Match(textNumber, @"\d+", RegexOptions.ECMAScript);

            return match.Value.Equals(textNumber);
        }

        /// <summary>
        /// Kiểm tra 1 string có phải là 1 dãy các chữ số với số lượng đã cho.
        /// </summary>
        /// <param name="textNumber"></param>
        /// <param name="count">Số các chữ số.</param>
        /// <returns></returns>
        public static bool IsNumber(this string textNumber, int count)
        {
            if (string.IsNullOrEmpty(textNumber)) return false;

            var match = Regex.Match(textNumber, @"\d{" + $"{count}" + @"}", RegexOptions.ECMAScript);

            return match.Value.Equals(textNumber);
        }

        /// <summary>
        /// Chuyển chuỗi ngày tháng dạng dd/MM/yyyy thành yyyy-MM-dd.
        /// </summary>
        /// <param name="textDate"></param>
        /// <returns></returns>
        public static string ToDate(this string textDate)
        {
            var match = Regex.Match(textDate, @"^(?<Day>\d{2})\/(?<Month>\d{2})\/(?<Year>\d{4})$");

            if (match != null && match.Value != "")
                return match.Groups["Year"].ToString() + "-" + match.Groups["Month"].ToString() + "-" + match.Groups["Day"].ToString();

            return null;
        }

        /// <summary>
        /// Chuyển chuỗi ngày tháng dạng dd/MM/yyyy thành kiểu DateTime.
        /// </summary>
        /// <param name="textDate"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime(this string textDate)
        {
            var match = Regex.Match(textDate, @"^(?<Day>\d{2})\/(?<Month>\d{2})\/(?<Year>\d{4})$");

            if (match != null && match.Value != "")
                return new DateTime(int.Parse(match.Groups["Year"].ToString()), int.Parse(match.Groups["Month"].ToString()), int.Parse(match.Groups["Day"].ToString()));

            return null;
        }

        /// <summary>
        /// Kiểm tra 1 string có phải là dạng ngày tháng dd/MM/yyyy.
        /// </summary>
        /// <param name="textDate"></param>
        /// <returns></returns>
        public static bool IsDate(this string textDate)
        {
            if (string.IsNullOrEmpty(textDate)) return false;

            var match = Regex.Match(textDate, @"^\d{1,2}\/\d{1,2}\/\d{4}$");

            return match.Value.Equals(textDate);
        }

        /// <summary>
        /// Xoá khoảng trắng 2 đầu, giữa các từ chỉ để lại 1 khoảng trắng.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToSingleSpace(this string text)
        {
            while(text.Contains("  "))
            {
                text = text.Replace("  ", " ");
            }

            return text.Trim();
        }

        /// <summary>
        /// Chuyển chuỗi sang dạng không dấu.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToUnsigned(this string input)
        {
            string signed = "ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ";
            string unsigned = "aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYY";

            for (int i = 0; i < input.Length; i++)
            {
                if (signed.Contains(input[i]))
                    input = input.Replace(input[i], unsigned[signed.IndexOf(input[i])]);
            }

            return input;
        }

        /// <summary>
        /// Trả về Description của enum.
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public static string ToStringDescription(this PersonGender gender)
        {
            FieldInfo info = gender.GetType().GetField(gender.ToString());
            DescriptionAttribute description = info.GetCustomAttribute<DescriptionAttribute>();
            return description.Description;
        }

        /// <summary>
        /// Trả về Description của enum.
        /// </summary>
        /// <param name="relation"></param>
        /// <returns></returns>
        public static string ToStringDescription(this HouseholdRelation relation)
        {
            FieldInfo info = relation.GetType().GetField(relation.ToString());
            DescriptionAttribute description = info.GetCustomAttribute<DescriptionAttribute>();
            return description.Description;
        }

        /// <summary>
        /// Trả về 1 số int tương đương với enum PersonGender dựa theo Description.
        /// </summary>
        /// <param name="input">Description của enum.</param>
        /// <returns>
        /// "Nam" return 1.
        /// <br>"Nữ" return 0.</br>
        /// <br>otherwise, return null.</br>
        /// </returns>
        public static int? ToGender(this string input)
        {
            if (input.Equals("Nam")) return 1;
            if (input.Equals("Nữ")) return 0;
            return null;
        }

        /// <summary>
        /// Trả về 1 số int tương đương với enum HouseholdRelation dựa theo Description.
        /// </summary>
        /// <param name="input">Description của enum.</param>
        /// <returns></returns>
        public static int? ToRelation(this string input)
        {
            switch (input)
            {
                case "Chủ hộ":
                    return 1;
                case "Vợ":
                    return 2;
                case "Chồng":
                    return 3;
                case "Con trai":
                    return 4;
                case "Con gái":
                    return 5;
                case "Cha":
                    return 6;
                case "Mẹ":
                    return 7;
                case "Ông":
                    return 8;
                case "Bà":
                    return 9;
                case "Cháu trai":
                    return 10;
                case "Cháu gái":
                    return 11;
                case "Tạm trú":
                    return 12;

                default:
                    return null;
            }
        }
    }

    

}
