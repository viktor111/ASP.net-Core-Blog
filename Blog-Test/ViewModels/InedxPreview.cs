using Blog_Test.Models;
using Blog_Test.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_Test.ViewModels
{
    public class InedxPreview : IPreview
    {
        public IEnumerable<string> PreviewArticleContent(IEnumerable<Article> Articles)
        {
            List<string> Preview = new List<string>();

            foreach (var article in Articles)
            {
                const int allowedPreviewChar = 300;

                string content = article.Content;
                string previewContent = string.Empty;

                int charNumInContent = 0;

                for (int i = 0; i < content.Length; i++)
                {
                    charNumInContent += 1;
                }

                if (charNumInContent > allowedPreviewChar)
                {
                    for (int i = 0; i < allowedPreviewChar; i++)
                    {

                        char cChar = content[i];
                        previewContent += cChar;

                    }
                    Preview.Add(previewContent);
                }

                else if (charNumInContent <= allowedPreviewChar)
                {
                    Preview.Add(content);
                }
            }

            return Preview;
        }
    }
}
