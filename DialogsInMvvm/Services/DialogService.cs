using DialogsInMvvm.Views;
using System;
using System.Collections.Generic;
using System.Windows;

namespace DialogsInMvvm.Services
{
    public class DialogService : IDialogService
    {
        private static Dictionary<Type, Type> _mappings = new();

        /// <summary>
        /// 註冊 Dialog，將 View 與 ViewModel 進行 mapping。
        /// View 為 Key，ViewModel 為 Value
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        /// <typeparam name="TViewModel"></typeparam>
        public static void RegisterDialog<TView, TViewModel>()
        {
            _mappings.Add(typeof(TViewModel), typeof(TView));
        }

        /// <summary>
        /// 無參數
        /// </summary>
        public void ShowDialog()
        {
            var dialog = new DialogWinodw();
            dialog.ShowDialog();
        }

        /// <summary>
        /// 一個參數
        /// </summary>
        /// <param name="message"></param>
        public void ShowDialog(string message)
        {
            var dialog = new DialogWinodw();

            var type = Type.GetType($"DialogsInMvvm.Views.{message}");
            dialog.Content = Activator.CreateInstance(type);

            dialog.ShowDialog();
        }

        /// <summary>
        /// 一個參數 + callback
        /// </summary>
        /// <param name="message"></param>
        /// <param name="callback"></param>
        public void ShowDialog(string message, Action<string> callback)
        {
            var dialog = new DialogWinodw();

            EventHandler closeEventHandler = null;
            closeEventHandler = (s, e) =>
            {
                callback(dialog.DialogResult.ToString());
                dialog.Closed -= closeEventHandler;
            };
            dialog.Closed += closeEventHandler;

            var type = Type.GetType($"DialogsInMvvm.Views.{message}");
            dialog.Content = Activator.CreateInstance(type);

            dialog.ShowDialog();
        }

        /// <summary>
        /// 一個參數 + callback；Internal Method
        /// </summary>
        /// <param name="message"></param>
        /// <param name="callback"></param>
        public void ShowDialogInternal(string message, Action<string> callback)
        {
            var type = Type.GetType($"DialogsInMvvm.Views.{message}");
            ShowDialogInternal(type, callback);
        }

        /// <summary>
        /// callback；Internal Method + 泛型
        /// 利用 mapping 方式，建立強型別
        /// </summary>
        /// <typeparam name="ViewModel"></typeparam>
        /// <param name="callback"></param>
        public void ShowDialog<TViewModel>(Action<string> callback)
        {
            var type = _mappings[typeof(TViewModel)];
            ShowDialogInternal(type, callback);
        }

        /// <summary>
        /// callback；Internal Method + 泛型 + ViewModelType
        /// 利用 mapping 方式，建立強型別
        /// </summary>
        /// <typeparam name="ViewModel"></typeparam>
        /// <param name="callback"></param>
        public void ShowDialogVMType<TViewModel>(Action<string> callback)
        {
            var type = _mappings[typeof(TViewModel)];
            ShowDialogInternalVMType(type, callback, typeof(TViewModel));
        }

        /// <summary>
        /// 分離 Method
        /// </summary>
        /// <param name="type"></param>
        /// <param name="callback"></param>
        private static void ShowDialogInternal(Type type, Action<string> callback)
        {
            var dialog = new DialogWinodw();

            EventHandler closeEventHandler = null;
            closeEventHandler = (s, e) =>
            {
                callback(dialog.DialogResult.ToString());
                dialog.Closed -= closeEventHandler;
            };
            dialog.Closed += closeEventHandler;

            dialog.Content = Activator.CreateInstance(type);

            dialog.ShowDialog();
        }

        /// <summary>
        /// 分離 Method，將 View 綁定 ViewModel（做到 Code behind）
        /// </summary>
        /// <param name="type"></param>
        /// <param name="callback"></param>
        /// <param name="vmType"></param>
        private static void ShowDialogInternalVMType(Type type, Action<string> callback, Type vmType)
        {
            var dialog = new DialogWinodw();

            EventHandler closeEventHandler = null;
            closeEventHandler = (s, e) =>
            {
                callback(dialog.DialogResult.ToString());
                dialog.Closed -= closeEventHandler;
            };
            dialog.Closed += closeEventHandler;

            var content = Activator.CreateInstance(type);
            
            if (vmType != null)
            {
                var vm = Activator.CreateInstance(vmType);
                (content as FrameworkElement).DataContext = vm;
            }

            dialog.Content = content;

            dialog.ShowDialog();
        }
    }
}
