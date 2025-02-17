﻿namespace System.Text.Kdl.Nodes
{
    /// <summary>
    ///   Options to control <see cref="KdlVertex"/> behavior.
    /// </summary>
    public struct KdlNodeOptions
    {
        /// <summary>
        ///   Specifies whether property names on <see cref="KdlNode"/> are case insensitive.
        /// </summary>
        public bool PropertyNameCaseInsensitive { get; set; }
    }
}
