using Microsoft.EntityFrameworkCore;

namespace Democode_DB
{
    public class ManageCategories
    {
        //-----------------------------------------------
        public void InsertCategory(Category category)
        {
            try
            {
                using MyStock stock = new MyStock();
                stock.Categories.Add(category);
                stock.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }//end InsertCategory

        //-----------------------------------------------
        public void UpdateCategory(Category category)
        {
            try
            {
                using MyStock stock = new MyStock();
                stock.Entry<Category>(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                stock.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }//end UpdateCategory

        //-----------------------------------------------
        public void DeleteCategory(Category category)
        {
            try
            {
                using MyStock stock = new MyStock();
                //Find Category by CategoryID
                var cate = stock.Categories.SingleOrDefault(c => c.CategoryID == category.CategoryID);
                stock.Categories.Remove(cate);
                stock.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }//end DeleteCategory

        //-----------------------------------------------
        public List<Category> GetCategories()
        {
            List<Category> listCategories = new List<Category>();
            try
            {
                using MyStock stock = new MyStock();
                listCategories = stock.Categories.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listCategories;
        }//end GetCategories

        //-----------------------------------------------
        public Category GetCategoryByID(int categoryID)
        {
            Category category = null;
            try
            {
                using MyStock stock = new MyStock();
                category = stock.Categories.SingleOrDefault(c => c.CategoryID == categoryID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return category;
        }//end GetCategoryByID
    }//end ManageCategories
}
