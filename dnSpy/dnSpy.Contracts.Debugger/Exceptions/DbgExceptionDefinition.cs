﻿/*
    Copyright (C) 2014-2017 de4dot@gmail.com

    This file is part of dnSpy

    dnSpy is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    dnSpy is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with dnSpy.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;

namespace dnSpy.Contracts.Debugger.Exceptions {
	/// <summary>
	/// Exception definition
	/// </summary>
	public struct DbgExceptionDefinition {
		/// <summary>
		/// Exception ID
		/// </summary>
		public DbgExceptionId Id { get; }

		/// <summary>
		/// Flags
		/// </summary>
		public DbgExceptionDefinitionFlags Flags { get; }

		/// <summary>
		/// Name shown in the UI
		/// </summary>
		public string DisplayName { get; }

		/// <summary>
		/// Description shown in the UI or null
		/// </summary>
		public string Description { get; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="id">Exception id</param>
		/// <param name="flags">Flags</param>
		public DbgExceptionDefinition(DbgExceptionId id, DbgExceptionDefinitionFlags flags)
			: this(id, flags, null, null) {
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="id">Exception id</param>
		/// <param name="flags">Flags</param>
		/// <param name="displayName">Display name or null to use <see cref="DbgExceptionId.Name"/></param>
		public DbgExceptionDefinition(DbgExceptionId id, DbgExceptionDefinitionFlags flags, string displayName)
			: this(id, flags, displayName, null) {
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="id">Exception id</param>
		/// <param name="flags">Flags</param>
		/// <param name="displayName">Display name or null to use <see cref="DbgExceptionId.Name"/></param>
		/// <param name="description">Description shown in the UI or null</param>
		public DbgExceptionDefinition(DbgExceptionId id, DbgExceptionDefinitionFlags flags, string displayName, string description) {
			if (id.Group == null)
				throw new ArgumentException();
			Id = id;
			Flags = flags;
			DisplayName = displayName ?? id.Name ?? throw new ArgumentNullException(nameof(displayName));
			Description = description;
		}

		/// <summary>
		/// ToString()
		/// </summary>
		/// <returns></returns>
		public override string ToString() => Description != null ? $"{Id.Group} - {DisplayName} - {Description}" : $"{Id.Group} - {DisplayName}";
	}
}