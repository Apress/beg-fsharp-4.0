#if INTERACTIVE
#else
module RecursiveTypeDefinitions
#endif

// A record representing an XML attribute:
type XmlAttribute =
    { AttribName: string;
      AttribValue: string; }

// A mutually recursive pair of types representing
// an Xml element and an XML tree:
type XmlElement =
    { ElementName: string;
      Attributes: list<XmlAttribute>;
      InnerXml: XmlTree }
      
and XmlTree =
  | Element of XmlElement
  | ElementList of list<XmlTree>
  | Text of string
  | Comment of string 
  | Empty
