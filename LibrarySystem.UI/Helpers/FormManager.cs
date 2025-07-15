using LibrarySystem.UI.Forms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LibrarySystem.UI.Helpers
{
    public static class FormManager
    {
        public static void ShowFormInMdi<T>(object constructorArg = null) where T : FormBase
        {
            // Find the active MDI container
            var mdiParent = Application.OpenForms
                .Cast<FormBase>()
                .FirstOrDefault(f => f.IsMdiContainer);

            ShowFormInMdi<T>(mdiParent, constructorArg);
        }
        /// <summary>
        /// Opens a form inside an MDI container if not already open. Optionally passes a constructor parameter (e.g., user).
        /// </summary>
        public static void ShowFormInMdi<T>(FormBase mdiParent, object constructorArg = null) where T : FormBase
        {
            if (mdiParent == null)
            {
                throw new ArgumentNullException(nameof(mdiParent));
            }

            mdiParent.BringToFront();
            if (mdiParent.WindowState == FormWindowState.Minimized)
                mdiParent.WindowState = FormWindowState.Maximized;

            var existingForm = Application.OpenForms.OfType<T>().FirstOrDefault();

            if (existingForm != null)
            {
                existingForm.BringToFront();
                if (existingForm.WindowState == FormWindowState.Minimized)
                    existingForm.WindowState = FormWindowState.Maximized;
                return;
            }

            FormBase formInstance;
            if (constructorArg == null)
            {
                formInstance = Activator.CreateInstance<T>();
            }
            else
            {
                formInstance = (FormBase)Activator.CreateInstance(typeof(T), constructorArg);
            }

            formInstance.MdiParent = mdiParent;

            formInstance.Show();
        }

        /// <summary>
        /// Opens a form as a standalone window (not MDI). Optionally passes a constructor parameter (e.g., user).
        /// </summary>
        public static void ShowForm<T>(object constructorArg = null) where T : FormBase
        {
            var existingForm = Application.OpenForms.OfType<T>().FirstOrDefault();

            if (existingForm != null)
            {
                existingForm.BringToFront();
                if (existingForm.WindowState == FormWindowState.Minimized)
                    existingForm.WindowState = FormWindowState.Maximized;
                return;
            }

            FormBase formInstance;

            if (constructorArg == null)
            {
                formInstance = Activator.CreateInstance<T>();
            }
            else
            {
                formInstance = (FormBase)Activator.CreateInstance(typeof(T), constructorArg);
            }

            formInstance.Show();
        }
        public static void ShowFormOnly<T>(object constructorArg = null) where T : FormBase
        {
            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                if (form is T)
                    continue;

                form.Close();
            }

            ShowForm<T>(constructorArg);
        }
    }
}
