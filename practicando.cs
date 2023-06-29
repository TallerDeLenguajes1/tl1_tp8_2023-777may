// // string[] discos = Directory.GetLogicalDrives();
// // foreach (var disc in discos)
// // {
// //     Console.WriteLine(disc);
// // }

// var directorio  = @"c:\PruebaDeDirectorio";
// if (!Directory.Exists(directorio)){
//     Directory.CreateDirectory(directorio);
// }
// if (Directory.GetFiles(directorio).Length <= 0){
//     Console.WriteLine("si");
// }
// // C:\Facultad\2do\TallerDeLenguaje1-2023\Practica\tl1_tp8_2023-777may\miCsv.csv
// string actual = @"C:\Facultad\2do\TallerDeLenguaje1-2023\Practica\tl1_tp8_2023-777may\miCsv.csv";
// if (File.Exists(actual)){
//     File.Move(actual, directorio + @"\miCsv.csv");
// }
// if (Directory.GetFiles(directorio).Length <= 0){
//     Console.WriteLine("si");
// }
// var texto = File.ReadAllLines(directorio + @"\miCsv.csv");
// foreach (var item in texto)
// {
//     Console.WriteLine("\t - " + item);
// }
// var renglon = texto[2].Split(";");
// foreach (var item in renglon)
// {
//     Console.WriteLine("\t" + item.Trim());
// }


