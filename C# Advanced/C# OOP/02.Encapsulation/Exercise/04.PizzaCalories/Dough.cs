using System;

namespace _04.PizzaCalories
{
    public class Dough
    {
        const double ConstCalories = 2;
        const double WhiteModifier = 1.5;
        const double WholegrainModifier = 1.0;
        const double CrispyModifier = 0.9;
        const double ChewyModifier = 1.1;
        const double HomemadeModifier = 1.0;

        private string flourType;
        private string bakingTechnique;
        private double weigh;
        //private double calories;

        public Dough(string flourType, string bakingTechnique, double weigh)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weigh = weigh;
        }

        public string FlourType
        {
            get { return flourType; }
            set
            {
                if (value != "White" && value != "Wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value;
            }
        }

        public string BakingTechnique
        {
            get { return bakingTechnique; }
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value;
            }
        }

        public double Weigh
        {
            get { return weigh; }
            set
            {
                if (value <= 0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                weigh = value;
            }
        }

        public double Calories => CalculateCalories();

        public double CalculateCalories()
        {
            double calories = ConstCalories * weigh;
            switch (FlourType.ToLower())
            {
                case "white":
                    calories *= WhiteModifier;
                    break;
                case "wholegrain":
                    calories *= WholegrainModifier;
                    break;
            }
             
            switch (BakingTechnique.ToLower())
            {
                case "crispy":
                    calories *= CrispyModifier;
                    break;
                case "chewy":
                    calories *= ChewyModifier;
                    break;
                case "homemade":
                    calories *= HomemadeModifier;
                    break;
            }

            return calories;
        }
    }
}
