﻿using System;

namespace Sr.Manager.Core.Security
{
    public class PermissionDefinition
    {
        public PermissionDefinition(string permission, string module, string router)
        {
            Permission = permission ?? throw new ArgumentNullException(nameof(permission));
            Module = module ?? throw new ArgumentNullException(nameof(module));
            Router = router ?? throw new ArgumentNullException(nameof(router));
        }

        public string Permission { get; }
        public string Module { get; }
        public string Router { get; }
        public override string ToString()
        {
            return base.ToString() + $" Permission:{Permission}、Module:{Module}、Router:{Router}";
        }
    }
}
