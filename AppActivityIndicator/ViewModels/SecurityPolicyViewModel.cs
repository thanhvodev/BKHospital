using System;
using System.Collections.Generic;
using System.Text;

namespace AppActivityIndicator.ViewModels
{
    public class SecurityPolicyViewModel : BaseViewModel
    {
        private List<string> standards;
        public List<string> Standards
        {
            get => standards;
            set => _ = SetProperty(ref standards, value);
        }
        public SecurityPolicyViewModel()
        {
            Title = "Chính sách bảo mật";
            Standards.Add("Quy định bảo vệ thông tin người dùng (GDPR) của Châu Âu.");
            Standards.Add("Quy định về bảo vệ thông tin sức khỏe (HIPPA) của Mỹ. ");
            Standards.Add("Yêu cầu An toàn An ninh mạng của Bộ Thông tin Truyền Thông Việt Nam (Thông tư 03/2017/TT-BTTTT)");

        }
    }
}
