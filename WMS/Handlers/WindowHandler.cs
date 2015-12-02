using System;
using System.Collections.Generic;
using System.Linq;
using WMS.Interfaces;
using WMS.GUI;
using WMS.Lang;
using System.Windows.Forms;

namespace WMS.Handlers
{
    public class WindowHandler : IWindowHandler
    {
        private ICore core;
        private Form main;
        private List<IGui> windowsOpen = new List<IGui>(); //The windows that are open
        private ILang lang = new LangDa(); //The start Language
        private bool da = true; //If the start language is danish

        public WindowHandler(ICore core, IMain main)
        {
            this.core = core; 
            main.Core = core; //Sets the core for main
            this.main = (Form)main; 
            main.UpdateLang(); //Sets the language for main
        }

        /// <summary>
        /// Runs the main window
        /// </summary>
        public void Run()
        {
            Application.Run(main);
        }

        #region Open new windows
        public void OpenInformation()
        {
            CreateWindow(new Information(core));
        }

        public void OpenLog()
        {
            CreateWindow(new Log(core));
        }

        public void OpenMove()
        {
            CreateWindow(new Move(core));
        }

        public void OpenRegister()
        {
            CreateWindow(new Register(core));
        }

        public void OpenReduce()
        {
            CreateWindow(new Reduce(core));
        }

        public void OpenWaste()
        {
            CreateWindow(new Waste(core));
        }
        #endregion

        /// <summary>
        /// Creates or shows the given form based on if a window of the same type is already open
        /// </summary>
        /// <param name="igui"></param>
        private void CreateWindow(IGui igui)
        {
            if (CanCreateForm(igui))
            {
                // Casts it to a form and adds the events
                Form gui = (Form)igui;
                gui.FormClosing += IGuiClosingEvent;
                gui.Move += IGuiMoveEvent;
                windowsOpen.Add(igui); //Adds it to the windows open list
                gui.Show(); 
                gui.Focus();
            } 
            else
            {
                Form form = ((Form)windowsOpen.Find(x => x.ToString().Equals(igui.ToString())));
                form?.BringToFront();
                form?.Focus();
            }
        }

        private void IGuiMoveEvent(object sender, EventArgs e)
        {
            IGui gui = ((IGui)sender);
            Form form = ((Form)sender);
            main.Left = form.Left - main.Width;
            main.Top = form.Top;
        }

        private void IGuiClosingEvent(object sender, FormClosingEventArgs e)
        {
            if (sender is IGui)
            {
                windowsOpen.Remove((IGui)sender);
            }
        }

        private bool CanCreateForm(object form)
        {
            if ((windowsOpen.Count(x => x.ToString().Equals(form.ToString())) < 1))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void Update(object caller)
        {
            foreach (var item in windowsOpen.FindAll(x => !(x.Equals(caller))))
            {
                item.UpdateGuiElements();
            }
        }

        public void Exit(string error)
        {
            MessageBox.Show(error, lang.ERROR);
            Environment.Exit(0);
        }

        public void ChangeLang(ILang lang)
        {
            this.lang = lang;
            ((IMain)main).UpdateLang();
            foreach (var item in windowsOpen)
            {
                item.UpdateLang();
            }
            ((IMain)main).UpdatePics(da);
            if (da)
            {
                da = false;
            }
            else
            {
                da = true;
            }
           
        }
    }
}
