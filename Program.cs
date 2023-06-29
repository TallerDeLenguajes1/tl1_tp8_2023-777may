
using clasesParaTarea;

var tareasPendientes = new List<Tarea>();
var tareasRealizadas = new List<Tarea>();

//cargar tareas
cargarTareas(tareasPendientes, 5);

string ? palabra;
int num = menu();
Tarea? aux;
while (num != 0)
{
    switch (num)
    {
    case 1:
        cambiarEstadoTareas(tareasPendientes, tareasRealizadas);
        break;
    case 2:
        mostrarTodasLasListas(tareasPendientes, tareasRealizadas);
        break;
    case 3:
        do
        {
            Console.WriteLine("Ingrese la palabra a buscar: ");
            palabra = Console.ReadLine();
        } while (palabra == null);
        Console.WriteLine(" Buscando la tarea con la palabra \"{0}\"", palabra);
        aux = BuscaTareaPorPalabra(tareasPendientes, tareasRealizadas, palabra);
        if(aux.Descripcion != null) aux.mostrarTarea();
        else 
        Console.WriteLine("No se ha encontrado tarea con la palabra \"{0}\"", palabra);
        break;
    }
    num = menu();
}
var directorio = ".";
var archivo = @"\horasTrabajadas.csv";
if(!File.Exists(directorio+archivo)){ 
    // using (StreamWriter sw = File.CreateText(directorio+archivo)) //si no existe lo crea
    // {
    //     sw.WriteLine("Horas trabajadas: ;");
    // }
    using (StreamWriter sw = new StreamWriter(directorio+archivo))
    {
        sw.WriteLine("Horas trabajadas: ;");
        // var horas = 0;
        // foreach (var tarea in tareasRealizadas)
        // {
        //     horas += tarea.Duracion;
        // }
        // sw.WriteLine(horas);
    }
}
using (StreamWriter sw = File.AppendText(directorio+archivo))
{
    var horas = 0;
    foreach (var tarea in tareasRealizadas)
    {
        horas += tarea.Duracion;
    }
    sw.Write(horas);
    sw.WriteLine(";");
    sw.Close();
}


int menu(){
    int num = 0;
    bool esNum = false;
    while (!esNum){
        Console.WriteLine("\nMENU");
        Console.WriteLine("  1: Cambiar estado de las tareas pendientes");
        Console.WriteLine("  2: Listar las tareas");
        Console.WriteLine("  3: Buscar tarea por descripcion");
        Console.WriteLine("  0: Salir \n");
        esNum = int.TryParse(Console.ReadLine(), out num);
    }
    return num;
}



void cambiarEstadoTareas(List<Tarea> tareasPendientes, List<Tarea> tareasRealizadas){
    string ? respuesta;
    if (tareasPendientes.Count == 0){
        Console.WriteLine("  No quedan tareas pendientes\n");
    }else{
        for (int i = 0; i < tareasPendientes.Count; i++)
        {
            do
            {
                Console.WriteLine("Ha realizado la tarea {0}: \"{1}\"? \n (si/no)", tareasPendientes[i].Id, tareasPendientes[i].Descripcion);
                respuesta = Console.ReadLine();
                if(respuesta != null) respuesta = respuesta.ToLower();
            } while (respuesta!= "si" && respuesta!= "no");

            if (respuesta == "si")
            {
                tareasRealizadas.Add(tareasPendientes[i]);
                tareasPendientes.Remove(tareasPendientes[i]);
                i --;
            }
        }
    }
}
void mostrarTodasLasListas(List<Tarea> tareasPendientes, List<Tarea> tareasRealizadas){
    if (tareasPendientes.Count == 0){
        Console.WriteLine("No hay tareas pendientes ");
    }else{
        Console.WriteLine("Las tareas pendientes son: ");
        for (int i = 0; i < tareasPendientes.Count; i++)
        {
            Console.Write($" {i+1}_");
            tareasPendientes[i].mostrarTarea();
        }
        Console.Write("\n\n");
    }
    if (tareasRealizadas.Count == 0){
        Console.WriteLine("No hay tareas realizadas ");
    }else{
        Console.WriteLine("Las tareas realizadas son: ");
        for (int i = 0; i < tareasRealizadas.Count; i++)
        {
            Console.Write($" {i+1}_");
            tareasRealizadas[i].mostrarTarea();
        }
        Console.Write("\n\n");
    }
}

Tarea BuscaTareaPorPalabra(List<Tarea> tareasPendientes, List<Tarea> tareasRealizadas, string palabra){
    foreach (var tarea in tareasPendientes)
    {
        if(tarea.Descripcion != null && tarea.Descripcion.IndexOf(palabra) >= 0){
            return tarea;
        }
    }
    foreach (var tarea in tareasRealizadas)
    {
        if(tarea.Descripcion != null && tarea.Descripcion.IndexOf(palabra) >= 0){
            return tarea;
        }
    }
    return new Tarea();
}
void cargarTareas(List<Tarea> tareasPendientes, int N){
    Tarea aux;
    string descripcion;
    Random rand = new Random();
    for (int i = 0; i < N; i++)
    {
        descripcion = ((descripA)rand.Next(5)).ToString("g") + " " + ((descripB)rand.Next(4)).ToString("g");

        aux = new Tarea(i, descripcion, rand.Next(16));
        tareasPendientes.Add(aux);
    }
}