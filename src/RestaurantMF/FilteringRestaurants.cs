using Data_Access.Model;
using System.Linq;

namespace RestaurantMF
{
    public class FilteringRestaurants
    {
        public List<Restaurant> GetRecommendedRestaurants(List<Restaurant> restaurants)
        {
            foreach (var rest in restaurants)
            {
                //Load sample data
                var sampleData = new RestMF.ModelInput()
                {
                    UserID = 1F,
                    RestID = rest.Id,
                };

                //Load model and predict output
                float Score = RestMF.Predict(sampleData).Score;
                if (Score < 2.5)
                {
                    restaurants.Remove(rest);
                }
            }
            return restaurants;
        }

    }
}