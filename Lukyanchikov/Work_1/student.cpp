#include "student.h"
#include "ui_student.h"

WindowStudent::WindowStudent(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::WindowStudent)
{
    ui->setupUi(this);
}

WindowStudent::~WindowStudent()
{
    delete ui;
}

void WindowStudent::on_pushButton_clicked()
{
    if(!Chipher.isEmpty() or !FIO.isEmpty() or !Group.isEmpty())

}
