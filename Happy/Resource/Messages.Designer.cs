﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18063
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Happy.Resource {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Happy.Resource.Messages", typeof(Messages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   使用此强类型资源类，为所有资源查找
        ///   重写当前线程的 CurrentUICulture 属性。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似 变量“{0}”对应的路径“{0}”的目录必须存在 的本地化字符串。
        /// </summary>
        internal static string Error_DirectoryMustExistxist {
            get {
                return ResourceManager.GetString("Error_DirectoryMustExistxist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 变量“{0}”的值必须大于等于“{1}”且小于等于“{2}” 的本地化字符串。
        /// </summary>
        internal static string Error_MustBetween {
            get {
                return ResourceManager.GetString("Error_MustBetween", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 变量“{0}”的值必须大于“{1}” 的本地化字符串。
        /// </summary>
        internal static string Error_MustGreaterThan {
            get {
                return ResourceManager.GetString("Error_MustGreaterThan", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 变量“{0}”的值必须大于等于“{1}” 的本地化字符串。
        /// </summary>
        internal static string Error_MustGreaterThanEqual {
            get {
                return ResourceManager.GetString("Error_MustGreaterThanEqual", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 变量“{0}”必须是类型“{1}” 的本地化字符串。
        /// </summary>
        internal static string Error_MustIsType {
            get {
                return ResourceManager.GetString("Error_MustIsType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 集合变量“{0}” 的长度必须大于零 的本地化字符串。
        /// </summary>
        internal static string Error_MustNotEmpty {
            get {
                return ResourceManager.GetString("Error_MustNotEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 变量“{0}” 不能是空引用 的本地化字符串。
        /// </summary>
        internal static string Error_MustNotNull {
            get {
                return ResourceManager.GetString("Error_MustNotNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 字符串变量“{0}” 不能是空引用且不能是空白字符串 的本地化字符串。
        /// </summary>
        internal static string Error_MustNotNullAndNotWhiteSpace {
            get {
                return ResourceManager.GetString("Error_MustNotNullAndNotWhiteSpace", resourceCulture);
            }
        }
    }
}
