﻿//  Dapplo - building blocks for desktop applications
//  Copyright (C) 2016-2019 Dapplo
// 
//  For more information see: http://dapplo.net/
//  Dapplo repositories are hosted on GitHub: https://github.com/dapplo
// 
//  This file is part of Dapplo.Config
// 
//  Dapplo.Config is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  Dapplo.Config is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
// 
//  You should have a copy of the GNU Lesser General Public License
//  along with Dapplo.Config. If not, see <http://www.gnu.org/licenses/lgpl.txt>.

namespace NKnife.Sweetting.Util
{
    /// <summary>
    /// This defines the order in which the setters are called
    /// </summary>
    public enum SetterOrders
    {
        /// <summary>
        /// This is the order for the setter which implements the IWriteProtectProperties
        /// </summary>
        WriteProtect = int.MinValue,
        /// <summary>
        /// This is the order for the setter which implements the INotifyPropertyChanging
        /// </summary>
        SetInfoInitializer = 0,
        /// <summary>
        /// This is the order for the setter which implements the INotifyPropertyChanging
        /// </summary>
        NotifyPropertyChanging = 1000,
        /// <summary>
        /// This is the order for the setter which implements the ITransactionalProperties
        /// </summary>
        Transaction = 2000,
        /// <summary>
        /// This is the order for the setter which implements the IHasChanges
        /// </summary>
        HasChanges = 3000,
        /// <summary>
        /// This is the order for the setter which places the value into the dictionary
        /// </summary>
        Dictionary = 4000,
        /// <summary>
        /// This is the order for the setter which implements the INotifyPropertyChanged
        /// </summary>
        NotifyPropertyChanged = 5000
    }
}
