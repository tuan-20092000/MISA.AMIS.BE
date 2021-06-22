using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class ServiceResult
    {
        // kết quả truy vấn hợp lệ hay không (true là có, false là không)
        public bool isValid { get; set; } = true;

        // message thông báo tới người dùng
        public List<string> Messengers { get; set; } = new List<string>();

        // dữ liệu truy vấn
        public List<Object> Data { get; set; } = new List<Object>();

        // tên cột bị lỗi
        public string EFieldError { get; set; } = string.Empty;
    }
}
