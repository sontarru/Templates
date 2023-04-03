// suppress CA1303
System.Console.WriteLine($"Hello, World{(char)33}");

// https://github.com/dotnet/roslyn-analyzers/issues/6141
sealed partial class Program {}
