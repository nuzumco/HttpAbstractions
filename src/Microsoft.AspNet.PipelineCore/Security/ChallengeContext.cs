﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.HttpFeature.Security;

namespace Microsoft.AspNet.PipelineCore.Security
{
    public class ChallengeContext : IChallengeContext
    {
        public ChallengeContext(IList<string> authenticationTypes, IDictionary<string, string> properties)
        {
            if (authenticationTypes == null)
            {
                throw new ArgumentNullException();
            }
            AuthenticationTypes = authenticationTypes;
            Properties = properties ?? new Dictionary<string, string>(StringComparer.Ordinal);
            Accepted = new List<string>();
        }

        public IList<string> AuthenticationTypes { get; private set; }

        public IDictionary<string, string> Properties { get; private set; }

        public IList<string> Accepted { get; private set; }
        
        public void Accept(string authenticationType, IDictionary<string, object> description)
        {
            Accepted.Add(authenticationType);
        }
    }
}