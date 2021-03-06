#region Released to Public Domain by Gael Fraiteur
/*----------------------------------------------------------------------------*
 *   This file is part of samples of PostSharp.                                *
 *                                                                             *
 *   This sample is free software: you have an unlimited right to              *
 *   redistribute it and/or modify it.                                         *
 *                                                                             *
 *   This sample is distributed in the hope that it will be useful,            *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of            *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.                      *
 *                                                                             *
 *----------------------------------------------------------------------------*/
#endregion


using System.Resources;
using PostSharp.Extensibility;

namespace DynamicComposition
{
    /// <summary>
    /// Provides a <see cref="MessageSource"/> from the current plug-in.
    /// </summary>
    internal class CompositionMessageSource
    {
        public static readonly MessageSource Instance = new MessageSource(
            "DynamicComposition",
            new ResourceManager( "DynamicComposition.Messages", typeof(CompositionMessageSource).Assembly ) );
    }
}