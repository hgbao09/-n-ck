﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace DoAnCK
{
    public partial class Form : System.Windows.Forms.Form
    {
        KhoHang _kho = new KhoHang();
        public Form(KhoHang kho)
        {
            InitializeComponent();
            _kho = kho;
            ngay_lbl.Text = "Ngày " + DateTime.Now.ToString("dd/MM/yyyy");
            OpenChildForm(new FormTrangChu(_kho));
        }
        private System.Windows.Forms.Form currentFormChild;
        private void OpenChildForm(System.Windows.Forms.Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            panelBody.Controls.Add(childForm);
            panelBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        bool sidebarExpand = true;
        bool hoadonExpand = false;


        private void hoadon_timer_Tick(object sender, EventArgs e)
        {
            if (hoadonExpand == false && hoadon_flp.Height < 210)
            {
                hoadon_flp.Height += 10;
                if (hoadon_flp.Height >= 210)
                {
                    hoadon_timer.Stop();

                }
            }
            else if (hoadonExpand == true && hoadon_flp.Height > 70)
            {
                hoadon_flp.Height -= 10;
                if (hoadon_flp.Height <= 70)
                {
                    hoadon_timer.Stop();

                }
            }
        }
        private void hoadon_btn_MouseEnter(object sender, EventArgs e)
        {
            hoadon_timer.Stop();
            hoadonExpand = false;
            hoadon_timer.Start();
        }

        private void hoadon_btn_MouseLeave(object sender, EventArgs e)
        {
            hoadon_timer.Stop();
            hoadonExpand = true;
            hoadon_timer.Start();
        }

        private void trangchu_btn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormTrangChu(_kho));
            trangchu_btn.Checked = true;
            nhaphang_btn.Checked = false;
            xuathang_btn.Checked = false;
            cuahang_btn.Checked = false;
            ncc_btn.Checked = false;
            hoadonnhap_btn.Checked = false;
            hoadonxuat_btn.Checked = false;
        }


        private void nhaphang_btn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormNhapXuat(_kho));
            trangchu_btn.Checked = false;
            nhaphang_btn.Checked = true;
            xuathang_btn.Checked = false;
            cuahang_btn.Checked = false;
            ncc_btn.Checked = false;
            hoadonnhap_btn.Checked = false;
            hoadonxuat_btn.Checked = false;
        }

        private void xuathang_btn_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new FormXuatHang(_kho));
            trangchu_btn.Checked = false;
            nhaphang_btn.Checked = false;
            xuathang_btn.Checked = true;
            cuahang_btn.Checked = false;
            ncc_btn.Checked = false;
            hoadonnhap_btn.Checked = false;
            hoadonxuat_btn.Checked = false;
        }

        private void cuahang_btn_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new FormCuaHang(_kho));
            trangchu_btn.Checked = false;
            nhaphang_btn.Checked = false;
            xuathang_btn.Checked = false;
            cuahang_btn.Checked = true;
            ncc_btn.Checked = false;
            hoadonnhap_btn.Checked = false;
            hoadonxuat_btn.Checked = false;
        }

        private void ncc_btn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new formNhaCungCap(_kho));
            trangchu_btn.Checked = false;
            nhaphang_btn.Checked = false;
            xuathang_btn.Checked = false;
            cuahang_btn.Checked = false;
            ncc_btn.Checked = true;
            hoadonnhap_btn.Checked = false;
            hoadonxuat_btn.Checked = false;
        }

        private void hoadonnhap_btn_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new FormHoaDon(_kho));
            trangchu_btn.Checked = false;
            nhaphang_btn.Checked = false;
            xuathang_btn.Checked = false;
            cuahang_btn.Checked = false;
            ncc_btn.Checked = false;
            hoadonnhap_btn.Checked = true;
            hoadonxuat_btn.Checked = false;
        }

        private void hoadonxuat_btn_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new FormHoaDon(_kho));
            trangchu_btn.Checked = false;
            nhaphang_btn.Checked = false;
            xuathang_btn.Checked = false;
            cuahang_btn.Checked = false;
            ncc_btn.Checked = false;
            hoadonnhap_btn.Checked = false;
            hoadonxuat_btn.Checked = true;
        }

    }
}
