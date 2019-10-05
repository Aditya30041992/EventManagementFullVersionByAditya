using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOL
{
    public class BookFood
    {
       // private string foodid;
        private string foodtype;
        private string mealtype;
        private string dishtype;
        private string dishname;
        private int customerId;

        public BookFood() { }
        public BookFood(string foodtype, string mealtype, string dishtype, string dishname, int customerId)
        {
           // this.foodid = foodid;
            this.foodtype = foodtype;
            this.mealtype = mealtype;
            this.dishtype = dishtype;
            this.dishname = dishname;
            this.customerId = customerId;
        }

        //public string FoodId
        //{
        //    get { return foodid; }
        //    set { foodid = value; }
        //}
        public string FoodType
        {
            get { return foodtype; }
            set { foodtype = value; }
        }
        public string MealType
        {
            get { return mealtype; }
            set { mealtype = value; }
        }
        public string DishType
        {
            get { return dishtype; }
            set { dishtype = value; }
        }
        public string DishName
        {
            get { return dishname; }
            set { dishname = value; }
        }
      
        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }
    }
}