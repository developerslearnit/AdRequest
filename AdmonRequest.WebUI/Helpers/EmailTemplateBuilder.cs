namespace AdmonRequest.WebUI.Helpers
{
    public class EmailTemplateBuilder
    {
        IWebHostEnvironment _env;

        public EmailTemplateBuilder(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string BuildNewRequestTemplate()
        {

            var _rootPath = _env.ContentRootPath;
            var templatePath = Path.Combine(_rootPath, $"MailTemplates\\NewRequestNotice.html");
            var body = string.Empty;
            using (StreamReader reader = new StreamReader(templatePath))
            {
                body = reader.ReadToEnd();
            }

            //body = body
            //        .Replace("{resetLink}", resetLink)
            //        .Replace("{name}", name)
            //        .Replace("{portalName}", portalName)
            //        .Replace("{accountId}", accountId)
            //        .Replace("{coyName}", portalName)
            //        .Replace("{copyYear}", DateTime.Now.Year.ToString())
            //        .Replace("{copYear}", DateTime.Now.Year.ToString());

            return body;
        }

    }
}
