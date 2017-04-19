using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class ChooseCategory
    {
        public List<String> Game { get; set; }
        public List<String> Pay { get; set; }
        public List<String> Account { get; set; }
        public ChooseCategory()
        {
            Game = new List<String>()
            {
                "Найден баг",
                "Жульничество",
                "Другое"
            };
            Pay = new List<String>()
            {
                "Проблемы с подпиской",
                "Отмена подписки",
                "Другое"
            };
            Account = new List<String>()
            {
                "Проблемы с учетной записью",
                "Восстановление учетной записи",
                "Другое"
            };
        }
    }
}
