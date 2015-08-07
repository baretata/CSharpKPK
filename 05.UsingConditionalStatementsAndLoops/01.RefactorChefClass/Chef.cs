namespace _01.RefactorChefClass
{
    using System;

    public class Chef
    {
        public void Cook()
        {
            Potato potato = this.GetPotato();
            Carrot carrot = this.GetCarrot();
            Bowl bowl;
            this.Peel(potato);

            this.Peel(carrot);
            bowl = this.GetBowl();
            this.Cut(potato);
            this.Cut(carrot);
            bowl.Add(carrot);

            bowl.Add(potato);
        }

        private Bowl GetBowl()
        {
            return new Bowl();
        }

        private Carrot GetCarrot()
        {
            return new Carrot();
        }

        private Potato GetPotato()
        {
            return new Potato();
        }

        private void Peel(Vegetable vegetableToPeel)
        {
            vegetableToPeel.Peel();
        }

        private void Cut(Vegetable vegetableToCut)
        {
            vegetableToCut.Cut();
        }
    }
}
