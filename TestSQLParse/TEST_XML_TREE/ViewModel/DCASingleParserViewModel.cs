using ICSharpCode.AvalonEdit.Document;
using Microsoft.Win32;
using MVVMCore.Helpers;
using MVVMCore.ViewModels;
using SQLParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using System.Collections.ObjectModel;

namespace DCA.ViewModel
{
    public class DCASingleParserViewModel : BaseViewModel
    {
        public ParseXmlToTree XmlParser = new ParseXmlToTree();

        private ObservableCollection<AbstractStatement> fullTree = new ObservableCollection<AbstractStatement>();
        public ObservableCollection<AbstractStatement> FullTree
        {
            get { return fullTree; }
            set
            {
                fullTree = value;
                RaisePropertyChanged<ObservableCollection<AbstractStatement>>(() => FullTree);
            }
        }
        public DCASingleParserViewModel(string title)
        {
            Title = title;
        }

        private string _title = string.Empty;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged<string>(() => Title);
            }
        }
        private TextDocument parsedXmlSourceCode = new TextDocument();
        public TextDocument ParsedXmlSourceCode
        {
            get
            {
                return parsedXmlSourceCode;
            }
            set
            {
                parsedXmlSourceCode = value;
                RaisePropertyChanged<TextDocument>(() => ParsedXmlSourceCode);
            }
        }

        private DelegateCommand parseFile;
        public ICommand ParseFile
        {
            get
            {
                if (parseFile == null)
                {
                    parseFile = new DelegateCommand(x => OnParseFile());
                }
                return parseFile;
            }
        }

        private void OnParseFile()
        {
            var parsedXml = Parser.Parse(SourceCode.Text);
            XmlParser.ParseXmlStrToTree(parsedXml);
            FullTree.Clear();

            FullTree.Add((XmlParser.Root));

            ParsedXmlSourceCode = new TextDocument(parsedXml);
        }
        private DelegateCommand openDocument;
        public ICommand OpenDocument
        {
            get
            {
                if (openDocument == null)
                {
                    openDocument = new DelegateCommand(x => OnOpenDocument());
                }
                return openDocument;
            }
        }
        private void OnOpenDocument()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            if (openDialog.ShowDialog() == true)
            {
                PathToFile = openDialog.FileName;
                var sourceCodeText = File.ReadAllText(pathToFile);
                SourceCode = new TextDocument(sourceCodeText);
            }
        }
        private string pathToFile = string.Empty;
        public string PathToFile
        {
            get
            {
                return pathToFile;
            }
            set
            {
                pathToFile = value;
                RaisePropertyChanged<string>(() => PathToFile);
            }
        }

        private TextDocument sourceCode = new TextDocument();
        public TextDocument SourceCode
        {
            get
            {
                return sourceCode;
            }
            set
            {
                sourceCode = value;
                RaisePropertyChanged<TextDocument>(() => SourceCode);
            }
        }
    }
}
