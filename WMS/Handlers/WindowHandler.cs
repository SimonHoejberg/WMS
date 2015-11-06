using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Interfaces;
using WMS.GUI;
using System.Windows.Forms;

namespace WMS.Handlers
{
    public class WindowHandler : IWindowHandler
    {
        private ICore core;
        private Form main;
        private List<IGui> windowsOpen = new List<IGui>();
        public WindowHandler(ICore core, IMain main)
        {
            this.core = core;
            main.Core = core;
            this.main = (Form)main;
            this.main.LocationChanged += MainLocationChanged;
        }

        public List<IGui> WindowsOpen { get { return windowsOpen; } }

        public void Run()
        {
            Application.Run(main);
        }

        public void OpenInformation()
        {
            CreateWindow(new Information(core));
        }

        public void OpenLog()
        {
            CreateWindow(new Log(core));
        }

        public void OpenLog(string itemNo)
        {
            CreateWindow(new Log(core, itemNo));
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

        private void CreateWindow(IGui gui)
        {
            if (CanCreateForm(gui.GetTypeOfWindow()))
            {
                Form temp = (Form)gui;
                temp.FormClosing += FormClosing;
                windowsOpen.Add(gui);
                temp.Activated += ChangeLocationOnMain;
                temp.LocationChanged += ChangeLocationOnMain;
                temp.Validating += ChangeLocationOnMain;
                temp.Show();
                temp.Focus();
            }
            else
            {
                String tempStrng = String.Format("Cannot open any more windows of the type {0}", gui.GetTypeOfWindow());
                MessageBox.Show(tempStrng, "Help");
            }
        }

        private void ChangeLocationOnMain(object sender, EventArgs e)
        {
            System.Drawing.Point location = ((Form)sender).Location;
            location.X -= main.Width;
            main.Location = location;
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

        private bool CanCreateForm(string type)
        {
            if ((windowsOpen.Count(x => ((IGui)x).GetTypeOfWindow().Equals(type)) < 4))
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
    }
}
