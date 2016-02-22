using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlashFinance_Web.Models
{
    public class Registers //Модель записів про доходи\витрати
    {
        //Ідентифікатор запису витрат
        public int Id { get; set; }
        //Категорія витрат 
        public string Register_Category { get; set; }
        //Тип витрат (деталізація категорії або підкатегорія)
        public string Register_Type { get; set; }
        //Дата коли була здійснена операція
        public DateTime RegisterDate { get; set; }
        //Баланс операції
        public int Register_Balance { get; set; }
        //Рахунок над яким вчинена операція 
        public string Register_Bill { get; set; }
        //Коментарі
        public string Comments { get; set; }
        

    }
}