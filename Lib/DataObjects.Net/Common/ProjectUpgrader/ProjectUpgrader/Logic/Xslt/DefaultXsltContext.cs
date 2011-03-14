// Copyright (C) 2003-2010 Xtensive LLC.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alex Yakunin
// Created:    2010.05.19

using System.Collections.Generic;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Linq;

namespace ProjectUpgrader.Logic.Xslt
{
  public sealed class DefaultXsltContext : XsltContext
  {
    private readonly XsltContext baseContext;
    private Dictionary<string, XsltFunction> functions;

    public string DefaultNamespacePrefix { get; private set; }

    public override string LookupNamespace(string prefix)
    {
      if (prefix.Length==0)
 	      return baseContext.LookupNamespace(DefaultNamespacePrefix);
      else
 	      return baseContext.LookupNamespace(prefix);
    }

    public override IXsltContextVariable ResolveVariable(string prefix, string name)
    {
      return baseContext.ResolveVariable(prefix, name);
    }

    public override IXsltContextFunction ResolveFunction(string prefix, string name, XPathResultType[] argTypes)
    {
      XsltFunction function;
      if (functions.TryGetValue(name, out function))
        return function;
      return baseContext.ResolveFunction(prefix, name, argTypes);
    }

    public override bool PreserveWhitespace(XPathNavigator node)
    {
      return baseContext.PreserveWhitespace(node);
    }

    public override int CompareDocument(string baseUri, string nextbaseUri)
    {
      return baseContext.CompareDocument(baseUri, nextbaseUri);
    }

    public override bool Whitespace
    {
      get { return baseContext.Whitespace; }
    }

    
    // Constructors

    public DefaultXsltContext(IXmlNamespaceResolver namespaceResolver, string defaultNamsepacePrefix = "",
      IEnumerable<XsltFunction> functions = null) 
    {
      DefaultNamespacePrefix = defaultNamsepacePrefix;
      var systemXmlAssembly = typeof (IXmlNamespaceResolver).Assembly;
      var type = systemXmlAssembly.GetType("MS.Internal.Xml.XPath.CompiledXpathExpr+UndefinedXsltContext", true);
      var ctor = type.GetConstructors().Single();
      baseContext = (XsltContext) ctor.Invoke(new object[] {namespaceResolver});
      this.functions = functions.ToDictionary(f => f.Name, f => f);
    }
  }
}