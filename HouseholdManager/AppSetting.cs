using HouseholdManager.BUS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace HouseholdManager
{
    /// <summary>
    /// Chứa các cài đặt của account đang đăng nhập.
    /// <br>account đăng nhập => LoadSetting => Deserialize setting và gán cho các thuộc tính tương ứng trên class này => binding cho các thuộc tính tương ứng trên các page.</br>
    /// </summary>
    [Serializable]    
    public class AppSetting : INotifyPropertyChanged
    {
        //Giữ setting mặc định cho phần mềm
        private static readonly AppSetting defaultSetting = new AppSetting();

        //Ban đầu gán cho setting mặc định, sau đó các thuộc tính thay đổi tuỳ theo account đăng nhập
        private static readonly AppSetting instance = (AppSetting)defaultSetting.MemberwiseClone();
        public static AppSetting Instance  => instance;

        private AppSetting() 
        {
            HeaderFont = new Font("Tahoma", 10, FontStyle.Bold);
            RowFont = new Font("Tahoma", 10, FontStyle.Regular);
            ButtonFont = new Font("Tahoma", 12, FontStyle.Bold);
            LabelFont = new Font("Tahoma", 16, FontStyle.Bold);
            TextColor = Color.DarkViolet;

            PersonPrivilege = new Dictionary<string, bool>();
            HouseholdPrivilege = new Dictionary<string, bool>();
            DonatePrivilege = new Dictionary<string, bool>();
            FeePrivilege = new Dictionary<string, bool>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private Font _headerFont;
        public Font HeaderFont
        {
            get => _headerFont;
            set
            {
                _headerFont = value;
                Notify();
            }
        }

        private Font _rowFont;
        public Font RowFont
        {
            get => _rowFont;
            set
            {
                _rowFont = value;
                Notify();
            }
        }

        private Font _buttonFont;
        public Font ButtonFont
        {
            get => _buttonFont;
            set
            {
                _buttonFont = value;
                Notify();
            }
        }

        private Font _labelFont;
        public Font LabelFont
        {
            get => _labelFont;
            set
            {
                _labelFont = value;
                Notify();
            }
        }

        private Color _textColor;
        public Color TextColor
        {
            get => _textColor;
            set
            {
                _textColor = value;
                Notify();
            }
        }

        /// <summary>
        /// Chứa danh sách các control trên pagePerson mà 1 account có thể sử dụng hay không.
        /// <br>Key = Control.Name@Control.Text</br>
        /// <br>Value = Control.Enabled</br>
        /// </summary>
        public Dictionary<string, bool> PersonPrivilege { get; set; }
        public Dictionary<string, bool> HouseholdPrivilege { get; set; }
        public Dictionary<string, bool> DonatePrivilege { get; set; }
        public Dictionary<string, bool> FeePrivilege { get; set; }


        /// <summary>
        /// Load setting mà account này đã save.
        /// </summary>
        /// <param name="username"></param>
        public static void LoadSetting(string setting)
        {
            AppSetting temp = (AppSetting)JsonConvert.DeserializeObject(setting, typeof(AppSetting));

            //Nếu không load được thì lấy setting mặc định;
            if (temp == null)
            {
                LoadDefault();               

                return;
            }

            instance.HeaderFont = temp.HeaderFont;
            instance.RowFont = temp.RowFont;
            instance.ButtonFont = temp.ButtonFont;
            instance.LabelFont = temp.LabelFont;
            instance.TextColor = temp.TextColor;

            instance.PersonPrivilege = temp.PersonPrivilege;
            instance.HouseholdPrivilege = temp.HouseholdPrivilege;
            instance.DonatePrivilege = temp.DonatePrivilege;
            instance.FeePrivilege = temp.FeePrivilege;
        }

        /// <summary>
        /// Serialize Setting của account này thành 1 string và save nó xuống database.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool SaveSetting(string username)
        {
            string setting = JsonConvert.SerializeObject(instance);

            var result = AccountBUS.Instance.UpdateAccount(username, null, null, null, setting);

            return result.Item4;

        }

        /// <summary>
        /// Load cài đặt mặc định.
        /// </summary>
        public static void LoadDefault()
        {
            instance.HeaderFont = defaultSetting.HeaderFont;
            instance.RowFont = defaultSetting.RowFont;
            instance.ButtonFont = defaultSetting.ButtonFont;
            instance.LabelFont = defaultSetting.LabelFont;
            instance.TextColor = defaultSetting.TextColor;

            instance.PersonPrivilege = defaultSetting.PersonPrivilege;
            instance.HouseholdPrivilege = defaultSetting.HouseholdPrivilege;
            instance.DonatePrivilege = defaultSetting.DonatePrivilege;
            instance.FeePrivilege = defaultSetting.FeePrivilege;
        }
    }
}
