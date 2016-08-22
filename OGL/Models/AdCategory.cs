namespace OGL.Models
{
    public class AdCategory
    {
        public AdCategory()
        {

        }
        public int Id { get; set; }
        public int KategoriaId { get; set; }
        public int OgloszenieId { get; set; }
        public virtual Category Category { get; set; }
        public virtual MyAd MyAd { get; set; }


    }
}
