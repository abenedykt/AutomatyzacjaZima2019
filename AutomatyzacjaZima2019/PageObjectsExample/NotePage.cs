using System;

namespace PageObjectsExample
{
    internal class NotePage
    {
        internal NotePage AddComment(ExampleComment exampleComment)
        {
            return new NotePage();
        }

        internal bool Has(ExampleComment exampleComment)
        {
            return false;
        }
    }
}