﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DoAnCK
{
    public partial class formNhaCungCap : System.Windows.Forms.Form
    {
        KhoHang _kho;
        
        int index;
        
        public formNhaCungCap(KhoHang kho)
        {
            InitializeComponent();
            _kho = kho;
        }

        
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            index = dataNCC.CurrentCell.RowIndex; 
            _kho.ds_ncc.RemoveAt(index);
            dataNCC.Rows.RemoveAt(index);
            _kho.LuuDanhSachNCC();
        }


        public NhaCungCap ncc;
        public void SetNCCInfo(NhaCungCap ncc)
        {
            this.ncc = ncc;
        }

        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            

            foreach (NhaCungCap ncc in _kho.ds_ncc)
            {
                dataNCC.Rows.Add(ncc.id_ncc, ncc.ten_ncc, ncc.sdt_ncc, ncc.dia_chi_ncc);
            }

            dataNCC.Enabled = dataNCC.Rows.Count > 0;

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void IDlabel_Click(object sender, EventArgs e)
        {

        }
        private bool isAddingMode = false;

        private void btnthem_Click(object sender, EventArgs e)
        {
            isAddingMode = true;
            ResetTextBoxes();
            ToggleTextBoxState(true);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (index < 0 || index >= _kho.ds_ncc.Count)
            {
                MessageBox.Show("Vui lòng chọn một nhà cung cấp để cập nhật!", "Thông báo");
                return;
            }

            DataGridViewRow selectedRow = dataNCC.Rows[index];
            selectedRow.Cells[0].Value = txtId.Text;
            selectedRow.Cells[1].Value = txtTen.Text;
            selectedRow.Cells[2].Value = txtSDT.Text;
            selectedRow.Cells[3].Value = txtDiaChi.Text;

            NhaCungCap nccToUpdate = _kho.ds_ncc[index];
            nccToUpdate.id_ncc = txtId.Text;
            nccToUpdate.ten_ncc = txtTen.Text;
            nccToUpdate.sdt_ncc = txtSDT.Text;
            nccToUpdate.dia_chi_ncc = txtDiaChi.Text;

            dataNCC.Refresh();
            _kho.LuuDanhSachNCC(); 

            MessageBox.Show("Cập nhật thành công!", "Thông báo");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isAddingMode)
            {
                string id = txtId.Text;
                string ten = txtTen.Text;
                string sdt = txtSDT.Text;
                string diaChi = txtDiaChi.Text;

                NhaCungCap ncc = new NhaCungCap(id, ten, sdt, diaChi);
                _kho.ds_ncc.Add(ncc);
                dataNCC.Rows.Add(id, ten, sdt, diaChi);

                _kho.LuuDanhSachNCC();

                MessageBox.Show("Đã lưu thành công!", "Thông báo");

               
                isAddingMode = false;

               
                ResetTextBoxes();
            }
            else
            {
                MessageBox.Show("Hãy nhấn nút Thêm trước khi lưu!", "Thông báo");
            }
        }
        private void ResetTextBoxes()
        {
            txtId.Clear();
            txtTen.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
        }
        private void ToggleTextBoxState(bool enabled)
        {
            txtId.Enabled = enabled;
            txtTen.Enabled = enabled;
            txtSDT.Enabled = enabled;
            txtDiaChi.Enabled = enabled;
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtTen.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();

            isAddingMode = false;

            txtId.Enabled = false;
            txtTen.Enabled = false;
            txtSDT.Enabled = false;
            txtDiaChi.Enabled = false;
        }

        private void DataNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            index = e.RowIndex; 
            DataGridViewRow row = dataNCC.Rows[index];

            if (row != null && row.Cells.Count >= 4)
            {
                txtId.Text = row.Cells[0].Value?.ToString() ?? string.Empty;
                txtTen.Text = row.Cells[1].Value?.ToString() ?? string.Empty;
                txtSDT.Text = row.Cells[2].Value?.ToString() ?? string.Empty;
                txtDiaChi.Text = row.Cells[3].Value?.ToString() ?? string.Empty;
            }
        }
    }
}


