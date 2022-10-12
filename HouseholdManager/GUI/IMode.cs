using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HouseholdManager.GUI
{
    /// <summary>
    /// Thực thi interface này để có thể chuyển đổi DisplayMode để lựa chọn hoặc hiển thị data chứa bên trong.
    /// <br>Kết quả lựa chọn thể hiện qua thuộc tính SelectedID.</br>
    /// </summary>
    public interface IMode
    {
        int SelectedID { get; set; }

        DisplayMode Mode { get; set; }

        void ChangeDisplayMode(DisplayMode mode);

        IButtonControl AcceptButton { get; set; }
    }

    /// <summary>
    /// Thiết lập chế độ hiển thị cho 1 control.
    /// </summary>
    public enum DisplayMode
    {
        /// <summary>
        /// Tìm, Xem, Thêm, Sửa, Xoá.
        /// </summary>
        Normal = 1,

        /// <summary>
        /// Tìm, Xem, Chọn.
        /// </summary>
        Select = 2
    }
}
