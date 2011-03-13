// Copyright (C) 2003-2010 Xtensive LLC.
// All rights reserved.
// For conditions of distribution and use, see license.
// Created by: Alex Yakunin
// Created:    2010.05.19

using System;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace ProjectUpgrader.Logic.Xslt
{
  public class XsltFunction : IXsltContextFunction
  {
    private XPathResultType[] argTypes;
    private XPathResultType returnType;
    private string name;
    private int minArgs;
    private int maxArgs;
    private Func<XsltContext, XPathNavigator, object[], object> implementation;

    public string Name
    {
      get { return name; }
    }

    public int Minargs
    {
      get { return minArgs; }
    }

    public int Maxargs
    {
      get { return maxArgs; }
    }

    public XPathResultType[] ArgTypes
    {
      get { return argTypes; }
    }

    public XPathResultType ReturnType
    {
      get { return returnType; }
    }

    public static string ArgumentToString(object xPathObject)
    {
      var iterator = xPathObject as XPathNodeIterator;
      if (iterator!=null) {
        if (iterator.MoveNext())
          return iterator.Current.ToString();
        else
          throw new ArgumentException("One of argument doesn't expand as string.");;
      }
      else
        return xPathObject.ToString();
    }


    // Constructors
    
    public XsltFunction(string name, XPathResultType[] argTypes, XPathResultType returnType,
      Func<XsltContext, XPathNavigator, object[], object> implementation, int? minArgs = null, int? maxArgs = null)
    {
      this.name = name;
      this.argTypes = argTypes;
      this.returnType = returnType;
      this.minArgs = minArgs ?? argTypes.Length;
      this.maxArgs = maxArgs ?? argTypes.Length;
      this.implementation = implementation;
    }

    public object Invoke(XsltContext context, object[] args, XPathNavigator navigator)
    {
      return implementation.Invoke(context, navigator, args);
    }
  }
}