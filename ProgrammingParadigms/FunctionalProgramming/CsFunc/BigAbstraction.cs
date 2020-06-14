using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CsFunc
{
    public class BigFileManager : IEnumerable<BlobFile>
    {
        private List<BlobFile> Files;

        public BigFileManager(string path)
        {

        }

        public IEnumerable<BlobFile> SearchFiles(Regex pattern)
        {

        }

        public BlobFile AddFile(string name, byte[] content)
        {

        }

        public int Count
        {

        }

        public event EventHandler<FileChangeEventArgs> FileAdded;

        public IEnumerator<BlobFile> GetEnumerator()
        {

        }

        IEnumerator IEnumerable.GetEnumerator()
        {

        }
    }

    public class FileChangeEventArgs : EventArgs
    {

    }

    public class BlobFile
    {

    }
}
