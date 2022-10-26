using DevExpress.Skins.XtraForm;
using HouseholdManager.BUS;
using Models;
using System;
using System.Windows.Forms;

namespace HouseholdManager.GUI
{
    public partial class fInsertMoney : DevExpress.XtraEditors.XtraForm
    {

        /// <summary>
        /// Hiện form để chọn số tiền cần đóng cho 1 hộ khẩu.
        /// </summary>
        /// <param name="household">Hộ khẩu.</param>
        /// <param name="item">1 đối tượng Donate hoặc Fee.</param>
        public fInsertMoney(Household household, object item)
        {
            InitializeComponent();

            this.household = household;

            switch (item)
            {
                case Donate donate:
                    this.donate = donate;
                    break;
                case Fee fee:
                    this.fee = fee;
                    break;
                default:
                    throw new Exception("Chỉ nhận Donate hoặc Fee.");
            }
           
            Initialize();

            LoadEvent();

        }

        public event EventHandler DonateInfoInserted;

        public event EventHandler FeeInfoInserted;

        Household household;

        Donate donate;

        Fee fee;

        void Initialize()
        {
            txbOwner.Text = household.Owner;

            if (donate != null)
            {
                txbName.Text = donate.Name;

                nmMoney.Value = (decimal)donate.MinValue;
            }

            if (fee != null)
            {
                txbName.Text = fee.Name;

                //Chỉ hiển thị cho người dùng xem, khi insert vào database số tiền sẽ được trigger tự động tính
                if (fee.Factor == FeeFactor.ByPerson) nmMoney.Value = (decimal)(fee.Value * household.MemberCount);

                if (fee.Factor == FeeFactor.ByHousehold) nmMoney.Value = (decimal)fee.Value;
            }
        }

        void LoadEvent()
        {
            btnInsert.Click += delegate { Insert(); };

            btnCancel.Click += delegate { Close(); };

            btnReset.Click += delegate { nmMoney.Value = 1000; };

        }

        void Insert()
        {
            if (donate != null)
            {
                if (string.IsNullOrEmpty(dtDate.Text) || string.IsNullOrEmpty(nmMoney.Text))
                {
                    MessageBox.Show("Không được để trống bất cứ mục nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var donateInfo = DonateBUS.Instance.InsertDonateInfo(household.ID, donate.ID, dtDate.Text, (double)nmMoney.Value);

                if (donateInfo != null)
                {
                    MessageBox.Show($"Đã thêm khoản đóng góp {donateInfo.Value:0,0} vnđ cho {donate.Name} của gia đình ông (bà) {household.Owner} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DonateInfoInserted?.Invoke(this, new InsertedEventArgs(donateInfo));

                    Close();
                }
                else
                {
                    MessageBox.Show("Đóng góp thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
               
            }

            if(fee != null)
            {
                if (string.IsNullOrEmpty(dtDate.Text) || string.IsNullOrEmpty(nmMoney.Text))
                {
                    MessageBox.Show("Không được để trống bất cứ mục nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var feeInfo = FeeBUS.Instance.InsertFeeInfo(household.ID, fee.ID, dtDate.Text, (double)nmMoney.Value);

                if (feeInfo != null)
                {
                    MessageBox.Show($"Đã thêm khoản tiền {feeInfo.Value:0,0} vnđ cho {fee.Name} của gia đình ông (bà) {household.Owner} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FeeInfoInserted?.Invoke(this, new InsertedEventArgs(feeInfo));

                    Close();
                }
                else
                {
                    MessageBox.Show("Nộp tiền thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                
            }
        }

        protected override FormPainter CreateFormBorderPainter()
        {
            return new MyFormPainter(this, DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel);
        }
    }
}