using LibrarySystem.App.Forms.Abstracts;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LibrarySystem.App.Helpers
{
    public static class FormManager
    {
        public static void ShowFormInMdi<T>(object constructorArg = null) where T : BaseForm
        {
            // Find the active MDI container
            var mdiParent = System.Windows.Forms.Application.OpenForms
                .Cast<BaseForm>()
                .FirstOrDefault(f => f.IsMdiContainer);

            ShowFormInMdi<T>(mdiParent, constructorArg);
        }
        /// <summary>
        /// Opens a form inside an MDI container if not already open. Optionally passes a constructor parameter (e.g., user).
        /// </summary>
        public static void ShowFormInMdi<T>(BaseForm mdiParent, object constructorArg = null) where T : BaseForm
        {
            if (mdiParent == null)
            {
                throw new ArgumentNullException(nameof(mdiParent));
            }

            mdiParent.BringToFront();
            if (mdiParent.WindowState == FormWindowState.Minimized)
                mdiParent.WindowState = FormWindowState.Maximized;

            var existingForm = System.Windows.Forms.Application.OpenForms.OfType<T>().FirstOrDefault();

            if (existingForm != null)
            {
                existingForm.BringToFront();
                if (existingForm.WindowState == FormWindowState.Minimized)
                    existingForm.WindowState = FormWindowState.Maximized;
                return;
            }

            BaseForm formInstance;
            if (constructorArg == null)
            {
                formInstance = Activator.CreateInstance<T>();
            }
            else
            {
                formInstance = (BaseForm)Activator.CreateInstance(typeof(T), constructorArg);
            }

            formInstance.MdiParent = mdiParent;

            formInstance.Show();
        }

        /// <summary>
        /// Opens a form as a standalone window (not MDI). Optionally passes a constructor parameter (e.g., user).
        /// </summary>
        public static void ShowForm<T>(object constructorArg = null) where T : BaseForm
        {
            var existingForm = System.Windows.Forms.Application.OpenForms.OfType<T>().FirstOrDefault();

            if (existingForm != null)
            {
                existingForm.BringToFront();
                if (existingForm.WindowState == FormWindowState.Minimized)
                    existingForm.WindowState = FormWindowState.Maximized;
                return;
            }

            BaseForm formInstance;

            if (constructorArg == null)
            {
                formInstance = Activator.CreateInstance<T>();
            }
            else
            {
                formInstance = (BaseForm)Activator.CreateInstance(typeof(T), constructorArg);
            }

            formInstance.Show();
        }
        public static void ShowFormOnly<T>(object constructorArg = null) where T : BaseForm
        {
            foreach (Form form in System.Windows.Forms.Application.OpenForms.Cast<Form>().ToList())
            {
                if (form is T)
                    continue;

                form.Close();
            }

            ShowForm<T>(constructorArg);
        }
        public static DialogResult ShowFormDialog<T>(object constructorArg = null) where T : BaseForm
        {
            BaseForm formInstance;

            if (constructorArg == null)
            {
                formInstance = Activator.CreateInstance<T>();
            }
            else
            {
                formInstance = (BaseForm)Activator.CreateInstance(typeof(T), constructorArg);
            }

            return formInstance.ShowDialog(); 
        }
        public static DialogResult ShowFormDialog<T>(object param1, object param2) where T : BaseForm
        {
            BaseForm formInstance;

            formInstance = (BaseForm)Activator.CreateInstance(typeof(T), param1, param2);

            return formInstance.ShowDialog(); 
        }
    }
}
