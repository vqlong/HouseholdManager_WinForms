using DevExpress.XtraEditors;
using HouseholdManager.BUS;
using HouseholdManager.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HouseholdManager.GUI
{
    public partial class pageMain : DevExpress.XtraEditors.XtraUserControl
    {
        public pageMain(Account account)
        {
            InitializeComponent();

            Account = account;

            LoadEvent();
        }

        Account _account;
        public Account Account
        {
            get => _account;
            set
            {
                _account = value;

                //SetAccountPrivilege(_account.Type);
            }
        }

        List<Person> _listPerson;
        /// <summary>
        /// 1 List&lt;Person&gt; dùng để binding với ListPerson của pPerson.
        /// </summary>
        public List<Person> ListPerson 
        { 
            get => _listPerson;
            set
            {
                _listPerson = value;

                StatisticPerson(_listPerson);
            } 
        }

        List<Household> _listHousehold;
        /// <summary>
        /// 1 List&lt;Household&gt; dùng để binding với ListHousehold của pHousehold.
        /// </summary>
        public List<Household> ListHousehold
        {
            get => _listHousehold;
            set
            {
                _listHousehold = value;

                StatisticHousehold(_listHousehold);
            }
        }

        List<DonateInfo2> _listDonateInfo2;
        public List<DonateInfo2> ListDonateInfo2
        {
            get => _listDonateInfo2;
            set
            {
                _listDonateInfo2 = value;

                GetDonateYear(_listDonateInfo2);

                StatisticDonateInfo(_listDonateInfo2);
            }
        }

        List<FeeInfo2> _listFeeInfo2;
        public List<FeeInfo2> ListFeeInfo2
        {
            get => _listFeeInfo2;
            set
            {
                _listFeeInfo2 = value;

                GetFeeYear(_listFeeInfo2);

                StatisticFeeInfo(_listFeeInfo2);
            }
        }

        private Font _labelFont;
        public Font LabelFont
        {
            get => _labelFont;
            set
            {
                _labelFont = value;

                Help.SetLabelFont(new List<Label> { labelStatistic, labelPerson, labelHousehold, labelDonate, labelFee }, _labelFont);
            }
        }

        private Color _textColor;
        public Color TextColor
        {
            get => _textColor;
            set
            {
                _textColor = value;
                Help.SetTextColor(new List<object> { labelStatistic, labelPerson, labelHousehold, labelDonate, labelFee }, _textColor);
            }
        }

        void LoadEvent()
        {
            //Click vào ô tổng thu để hiện lại tổng thu
            nmTotalDonate.Click += delegate
            {
                lkuDonateYear.EditValue = null;

                StatisticDonateInfo(ListDonateInfo2);
            };

            nmTotalFee.Click += delegate
            {
                lkuFeeYear.EditValue = null;

                StatisticFeeInfo(ListFeeInfo2);
            };

            //Lấy ra các loại đóng góp (Donate) được đóng trong năm này
            lkuDonateYear.EditValueChanged += delegate
            {
                if (lkuDonateYear.EditValue == null)
                {
                    lkuDonate.EditValue = null;

                    lkuDonate.Enabled = false;

                    return;
                }

                lkuDonate.Enabled = true;

                var listDonateInfo = ListDonateInfo2.FindAll(info => info.DateContribute.Year == (int)lkuDonateYear.EditValue);

                var groupDonate = listDonateInfo.GroupBy(info => info.DonateID);

                var listDonate = new List<Donate>();

                groupDonate.ToList().ForEach(iGroup => listDonate.Add(DonateBUS.Instance.GetDonateByID(iGroup.Key)));

                lkuDonate.Properties.DataSource = listDonate;
                lkuDonate.Properties.DisplayMember = "Name";
                //lkuDonate.Properties.ValueMember = "ID";
                lkuDonate.Properties.Columns[0].Caption = "ID";
                lkuDonate.Properties.Columns[0].FieldName = "ID";
                lkuDonate.Properties.Columns[0].Width = 5;
                lkuDonate.Properties.Columns[1].Caption = "Khoản đóng góp";
                lkuDonate.Properties.Columns[1].FieldName = "Name";
                lkuDonate.Properties.Columns[2].Caption = "Ngày kêu gọi";
                lkuDonate.Properties.Columns[2].FieldName = "DateArise";

            };

            //Lấy ra danh sách các khoản đóng góp theo loại và năm đóng => tính tổng
            lkuDonate.EditValueChanged += delegate
            {
                if (lkuDonate.EditValue == null) return;

                var list = ListDonateInfo2.FindAll(info => info.DonateID == ((Donate)lkuDonate.EditValue).ID && info.DateContribute.Year == (int)lkuDonateYear.EditValue);

                StatisticDonateInfo(list);
            };

            //Lấy ra các loại thu phí (Fee) được đóng trong năm này
            lkuFeeYear.EditValueChanged += delegate
            {
                if (lkuFeeYear.EditValue == null)
                {
                    lkuFee.EditValue = null;

                    lkuFee.Enabled = false;

                    return;
                }

                lkuFee.Enabled = true;

                var listFeeInfo = ListFeeInfo2.FindAll(info => info.DatePay.Year == (int)lkuFeeYear.EditValue);

                var groupFee = listFeeInfo.GroupBy(info => info.FeeID);

                var listFee = new List<Fee>();

                groupFee.ToList().ForEach(iGroup => listFee.Add(FeeBUS.Instance.GetFeeByID(iGroup.Key)));

                lkuFee.Properties.DataSource = listFee;
                lkuFee.Properties.DisplayMember = "Name";
                //lkuFee.Properties.ValueMember = "ID";
                lkuFee.Properties.Columns[0].Caption = "ID";
                lkuFee.Properties.Columns[0].FieldName = "ID";
                lkuFee.Properties.Columns[0].Width = 5;
                lkuFee.Properties.Columns[1].Caption = "Khoản thu phí";
                lkuFee.Properties.Columns[1].FieldName = "Name";
                lkuFee.Properties.Columns[2].Caption = "Ngày phát sinh";
                lkuFee.Properties.Columns[2].FieldName = "DateArise";

            };

            //Lấy ra danh sách các khoản thu phí theo loại và năm đóng => tính tổng
            lkuFee.EditValueChanged += delegate
            {
                if (lkuFee.EditValue == null) return;

                var list = ListFeeInfo2.FindAll(info => info.FeeID == ((Fee)lkuFee.EditValue).ID && info.DatePay.Year == (int)lkuFeeYear.EditValue);

                StatisticFeeInfo(list);
            };
        }

        void GetDonateYear(List<DonateInfo2> listDonateInfo2)
        {
            //Lấy ra nhóm các năm trong DonateInfo làm DataSource cho lkuDonateYear
            var groupDonateYear = listDonateInfo2.GroupBy(info => info.DateContribute.Year);

            var listDonateYear = new List<int>();

            groupDonateYear.ToList().ForEach(iGroup => listDonateYear.Add(iGroup.Key));

            listDonateYear.Sort();

            lkuDonateYear.Properties.DataSource = listDonateYear;

            lkuDonateYear.EditValue = null;
        }

        void GetFeeYear(List<FeeInfo2> listFeeInfo2)
        {
            //Lấy ra nhóm các năm trong FeeInfo làm DataSource cho lkuFeeYear
            var groupFeeYear = listFeeInfo2.GroupBy(info => info.DatePay.Year);

            var listFeeYear = new List<int>();

            groupFeeYear.ToList().ForEach(iGroup => listFeeYear.Add(iGroup.Key));

            listFeeYear.Sort();

            lkuFeeYear.Properties.DataSource = listFeeYear;

            lkuFeeYear.EditValue = null;
        }

        void StatisticPerson(List<Person> list)
        {
            if (list == null) return;

            nmTotalPerson.Value = list.Count();
            nmMan.Value = list.Count(person => person.Gender == PersonGender.Male);
            nmWoman.Value = nmTotalPerson.Value - nmMan.Value;
            nmTempResident.Value = list.Count(person => person.Relation == HouseholdRelation.TemporaryResident);
            nmPermanentResident.Value = nmTotalPerson.Value - nmTempResident.Value;
            nmChild.Value = list.Count(person => DateTime.Today.Year - person.DateOfBirth.Year < 10);
            nmTeenager.Value = list.Count(person => 10 <= DateTime.Today.Year - person.DateOfBirth.Year && DateTime.Today.Year - person.DateOfBirth.Year < 18);
            nmAdult.Value = list.Count(person => 18 <= DateTime.Today.Year - person.DateOfBirth.Year && DateTime.Today.Year - person.DateOfBirth.Year < 60);
            nmElder.Value = nmTotalPerson.Value - nmChild.Value - nmTeenager.Value - nmAdult.Value;
        }

        void StatisticHousehold(List<Household> list) => nmTotalHousehold.Value = list.Count();
        //{
        //    if (list == null) return;

        //    nmTotalHousehold.Value = list.Count();
        //}

        /// <summary>
        /// Tính tổng số tiền.
        /// </summary>
        /// <param name="list"></param>
        void StatisticDonateInfo(List<DonateInfo2> list) => nmTotalDonate.Value = (decimal)list.Sum(info => info.Value);

        void StatisticFeeInfo(List<FeeInfo2> list) => nmTotalFee.Value = (decimal)list.Sum(info => info.Value);

    }
}
