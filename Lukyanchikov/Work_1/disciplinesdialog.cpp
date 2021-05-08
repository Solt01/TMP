#include "disciplinesdialog.h"
#include "ui_disciplinesdialog.h"
#include "mainwindow.h"
DisciplinesDialog::DisciplinesDialog(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::DisciplinesDialog)
{
    ui->setupUi(this);
    QDialog::setWindowTitle("Дисциплина");

}
void DisciplinesDialog::addList(QList<Student> _list)
{
    list = _list;

    for(int i = 0; i < list.size(); i++)
        ui->comboBox->addItem(list.at(i).FIO);
}

DisciplinesDialog::~DisciplinesDialog()
{
    delete ui;
}

void DisciplinesDialog::on_pushButton_clicked()
{
    if(ui->nameLine->text().isEmpty() or ui->dateLine->text().isEmpty() or ui->scoreLine->text().isEmpty() or ui->comboBox->currentIndex() == -1)
        QMessageBox::information(this,"Ошибка","Вы не заполнили все поля");
    else
    {
        nameStudent = ui->comboBox->currentText();
        name = ui->nameLine->text();
        date = ui->dateLine->text();
        score = ui->scoreLine->text();
        this->close();
    }
}
