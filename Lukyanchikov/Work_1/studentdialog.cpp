#include "studentdialog.h"
#include "ui_studentdialog.h"

StudentDialog::StudentDialog(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::StudentDialog)
{
    ui->setupUi(this);
    QDialog::setWindowTitle("Студент");
}

StudentDialog::~StudentDialog()
{
    delete ui;
}

void StudentDialog::on_addButton_clicked()
{
    if(ui->fio->text().isEmpty() or ui->chipher->text().isEmpty() or ui->group->text().isEmpty())
        QMessageBox::information(this,"Ошибка","Вы не заполнили все поля");
    else
    {
        fio = ui->fio->text();
        chipher = ui->chipher->text();
        group = ui->group->text();
        this->close();
    }
}
