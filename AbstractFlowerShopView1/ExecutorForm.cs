﻿using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.ViewModel;
using System;
using System.Windows.Forms;

namespace AbstractFlowerShopView1
{
    public partial class ExecutorForm : Form
    {
        public int Id { set { id = value; } }
        private int? id;

        public ExecutorForm()
        {
            InitializeComponent();
        }
        private void FormExecutor_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    ExecutorViewModel executor = APICustomer.GetRequest<ExecutorViewModel>("api/Executor/ElementGet/" + id.Value);
                    textBoxFIO.Text = executor.ExecutorFIO;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFIO.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    APICustomer.PostRequest<ExecutorBindingModel, bool>("api/Executor/UpdateElement", new ExecutorBindingModel
                    {
                        Id = id.Value,
                        ExecutorFIO = textBoxFIO.Text
                    });
                }
                else
                {
                    APICustomer.PostRequest<ExecutorBindingModel, bool>("api/Executor/AddElement", new ExecutorBindingModel
                    {
                        ExecutorFIO = textBoxFIO.Text
                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
