using System.Text.Json;

// Parse arguments
var (command, param) = args.Length switch
{
    0 => throw new InvalidOperationException("Usage: your_bittorrent.sh <command> <param>"),
    1 => throw new InvalidOperationException("Usage: your_bittorrent.sh <command> <param>"),
    _ => (args[0], args[1])
};

// Parse command and act accordingly
if (command == "decode")
{
    // You can use print statements as follows for debugging, they'll be visible when running tests.
    // Console.WriteLine("Logs from your program will appear here!");

    // Uncomment this line to pass the first stage
    var encodedValue = param;
    if (Char.IsDigit(encodedValue[0]))
    {
       // Example: "5:hello" -> "hello"
       var colonIndex = encodedValue.IndexOf(':');
       if (colonIndex != -1)
       {
           var strLength = int.Parse(encodedValue[..colonIndex]);
           var strValue = encodedValue.Substring(colonIndex + 1, strLength);
           Console.WriteLine(JsonSerializer.Serialize(strValue));
       }
       else
       {
           throw new InvalidOperationException("Invalid encoded value: " + encodedValue);
       }
    }
    else if (encodedValue.StartsWith('i') && encodedValue.EndsWith('e')) 
    { 
        var encodedInt = encodedValue.Substring(encodedValue.IndexOf('i') + 1, encodedValue.IndexOf('e') - 1); 
        bool parsed = Int64.TryParse(encodedInt,  out Int64 decodedInt);

        if (parsed) {
            Console.WriteLine(JsonSerializer.Serialize(decodedInt));
        } else {
            throw new InvalidOperationException("Invalid encoded value: " + encodedInt);
        }     
    }   
    else
    {
       throw new InvalidOperationException("Unhandled encoded value: " + encodedValue);
    }
}
else
{
    throw new InvalidOperationException($"Invalid command: {command}");
}
