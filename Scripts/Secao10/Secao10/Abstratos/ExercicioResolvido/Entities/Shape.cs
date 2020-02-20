using Secao10.Abstratos.ExercicioResolvido.Entities.Enums;

namespace Secao10.Abstratos.ExercicioResolvido.Entities
{
    abstract class Shape
    {

        public Color color { get; set; }

        protected Shape(Color color)
        {
            this.color = color;
        }

        public abstract double Area();

    }
}
