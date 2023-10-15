﻿using Sr.Manager.Core.Domains.Common.Base;

namespace Sr.Manager.Service.Core.Files.Output;

public class FileDto : EntityDto
{
    public string Key { get; set; }
    public string Path { get; set; }
    public string Url { get; set; }
}
