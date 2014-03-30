namespace ParserApplication

type public  Parser() = 
    member this.X = "F#"
    member public this.StartParse(node : System.Xml.Linq.XElement) = 
        node.Name
