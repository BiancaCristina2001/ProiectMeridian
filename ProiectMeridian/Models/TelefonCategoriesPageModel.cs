using Microsoft.AspNetCore.Mvc.RazorPages;
using ProiectMeridian.Data;


namespace ProiectMeridian.Models
{
    public class TelefonCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(ProiectMeridianContext context,
        Telefon telefon)
        {
            var allCategories = context.Category;
            var telefonCategories = new HashSet<int>(telefon.TelefonCategories.Select(c => c.CategoryID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = telefonCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateTelefonCategories(ProiectMeridianContext context,
        string[] selectedCategories, Telefon telefonToUpdate)
        {
            if (selectedCategories == null)
            {
                telefonToUpdate.TelefonCategories = new List<TelefonCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var telefonCategories = new HashSet<int>
            (telefonToUpdate.TelefonCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!telefonCategories.Contains(cat.ID))
                    {
                        telefonToUpdate.TelefonCategories.Add(
                        new TelefonCategory
                        {
                            TelefonID = telefonToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (telefonCategories.Contains(cat.ID))
                    {
                        TelefonCategory courseToRemove
                        = telefonToUpdate
                        .TelefonCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}