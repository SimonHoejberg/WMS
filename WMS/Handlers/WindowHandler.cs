using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private List<IGui> windowsOpen = new List<IGui>();
        private ILang lang = new LangDa();
        private bool da = true;

        public WindowHandler(ICore core, IMain main)
        {
            this.core = core;
            main.Core = core;
            this.main = (Form)main;
            main.lang = lang;
            main.UpdateLang();
            this.main.LocationChanged += MainLocationChanged;
        }

        public List<IGui> WindowsOpen { get { return windowsOpen; } }

        public void Run()
        {
            Application.Run(main);
        }

        public void OpenInformation()
        {
            CreateWindow(new Information(core,lang));
        }

        public void OpenLog()
        {
            CreateWindow(new Log(core,lang));
        }

        public void OpenLog(string itemNo)
        {
            CreateWindow(new Log(core, itemNo,lang));
        }

        public void OpenMove()
        {
            CreateWindow(new Move(core,lang));
        }

        public void OpenRegister()
        {
            CreateWindow(new Register(core,lang));
        }

        public void OpenReduce()
        {
            CreateWindow(new Reduce(core,lang));
        }

        public void OpenWaste()
        {
            CreateWindow(new Waste(core,lang));
        }

        private void CreateWindow(IGui gui)
        {
            if (CanCreateForm(gui))
            {
                Form temp = (Form)gui;
                temp.FormClosing += FormClosing;
                windowsOpen.Add(gui);
                temp.Move += Temp_Move;
                temp.Show();
                temp.Focus();
            }
            else
            {
                Form form = ((Form)windowsOpen.Find(x => x.ToString().Equals(gui.ToString())));
                form?.BringToFront();
                form?.Focus();
            }
        }

        private void Temp_Move(object sender, EventArgs e)
        {
            IGui gui = ((IGui)sender);
            Form form = ((Form)sender);
            main.Left = form.Left - main.Width;
            main.Top = form.Top;
        }

        private void FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sender is IGui)
            {
                windowsOpen.Remove((IGui)sender);
            }
        }

        private void MainLocationChanged(object sender, EventArgs e)
        {
            main.BringToFront();
        }

        private bool CanCreateForm(object type)
        {
            if ((windowsOpen.Count(x => x.ToString().Equals(type.ToString())) < 1))
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
            foreach (var item in WindowsOpen.FindAll(x => !(x.Equals(caller))))
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
            ((IMain)main).lang = lang;
            ((IMain)main).UpdateLang();
            foreach (var item in WindowsOpen)
            {
                item.UpdateLang(lang);
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
