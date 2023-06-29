namespace clasesParaTarea
{
    public enum descripA{
        limpiar,
        pintar,
        cambiar,
        ordenar,
        comprar
    }
    public enum descripB{
        ropa,
        cuadros,
        lamparas,
        herramientas
    }
    public class Tarea{
        private int id;
        private string? descripcion;
        private int duracion;
        public Tarea (){}
        public Tarea (int idTarea, string descripcionTarea, int duracionTarea){
            id = idTarea;
            descripcion = descripcionTarea;
            duracion = duracionTarea;
        }

        public int Id { get => id;}
        public string? Descripcion { get => descripcion;}
        public int Duracion { get => duracion;}
        public void mostrarTarea(){
            Console.WriteLine($"\t\t\t {Id}\n\t\"{Descripcion}\"\n\t duracion: {Duracion} horas");
        }
    }

    
}
