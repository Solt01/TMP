#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    QMainWindow::setWindowTitle("Первая программа");
    QStringList titleGroup = {"Группа"};
    /*
    ui->groupTableWidget->setColumnCount(1);
    ui->groupTableWidget->setHorizontalHeaderLabels(titleGroup);
    */
    QStringList titleStudent = {"Группа","ФИО","Шифр"};
    ui->studentTableWidget->setColumnCount(3);
    ui->studentTableWidget->setHorizontalHeaderLabels(titleStudent);

    QStringList titleDisciplines = {"Студент","Предмет","Посещение","Оценка"};
    ui->disciplineTableWidget->setColumnCount(4);
    ui->disciplineTableWidget->setHorizontalHeaderLabels(titleDisciplines);
}

MainWindow::~MainWindow()
{
    delete ui;
}
void MainWindow::updateDisciplineTable()
{
    ui->disciplineTableWidget->clearContents();
    ui->disciplineTableWidget->setRowCount(0);

    QMap<QString, Disciplines>::const_iterator i = dataModelDisciplines.constBegin();
    while (i != dataModelDisciplines.constEnd()) {


        ui->disciplineTableWidget->setRowCount(ui->disciplineTableWidget->rowCount() + 1);
        QTableWidgetItem *studentNameItem = new QTableWidgetItem;
        QTableWidgetItem *nameItem = new QTableWidgetItem;
        QTableWidgetItem *dateItem = new QTableWidgetItem;
        QTableWidgetItem *scoreItem = new QTableWidgetItem;

        studentNameItem->setText(i.value().student);
        nameItem->setText(i.value().name);
        dateItem->setText(i.value().date);
        scoreItem->setText(i.value().score);

        ui->disciplineTableWidget->setItem(ui->disciplineTableWidget->rowCount() - 1, 0, studentNameItem);
        ui->disciplineTableWidget->setItem(ui->disciplineTableWidget->rowCount() - 1, 1, nameItem);
        ui->disciplineTableWidget->setItem(ui->disciplineTableWidget->rowCount() - 1, 2, dateItem);
        ui->disciplineTableWidget->setItem(ui->disciplineTableWidget->rowCount() - 1, 3, scoreItem);

        ++i;
    }

}
void MainWindow::updateStudentTable()
{

    ui->studentTableWidget->clearContents();
    ui->studentTableWidget->setRowCount(0);
    /*
    ui->groupTableWidget->clearContents();
    ui->groupTableWidget->setRowCount(0);
    */
    QMap<QString, Student>::const_iterator i = dataModel.constBegin();

    while (i != dataModel.constEnd()) {


        ui->studentTableWidget->setRowCount(ui->studentTableWidget->rowCount() + 1);
        QTableWidgetItem *groupItem = new QTableWidgetItem;
        QTableWidgetItem *fioItem = new QTableWidgetItem;
        QTableWidgetItem *chipherItem = new QTableWidgetItem;

        groupItem->setText(i.value().Group);
        fioItem->setText(i.value().FIO);
        chipherItem->setText(i.value().Chipher);

        ui->studentTableWidget->setItem(ui->studentTableWidget->rowCount() - 1, 0, groupItem);
        ui->studentTableWidget->setItem(ui->studentTableWidget->rowCount() - 1, 1, fioItem);
        ui->studentTableWidget->setItem(ui->studentTableWidget->rowCount() - 1, 2, chipherItem);


        ++i;
    }
}
void MainWindow::on_addStudentButton_clicked()
{
    StudentDialog studentDialog;
    studentDialog.setModal(true);
    studentDialog.exec();

    if(!studentDialog.fio.isEmpty() and !studentDialog.chipher.isEmpty() and !studentDialog.group.isEmpty())
    {
        Student newStudent = Student(studentDialog.fio,studentDialog.chipher,studentDialog.group);

        dataModel.insert(newStudent.Group, newStudent);
        list.append(newStudent);
        updateStudentTable();

    }

}

void MainWindow::on_removeStudentButton_clicked()
{
    if(dataModel.isEmpty())
        QMessageBox::information(this,"Ошибка","Список студентов пуст");
    else{
        QModelIndexList indexes =  ui->studentTableWidget->selectionModel()->selectedRows();
        int countRow = indexes.count();

        for (int i = countRow; i > 0; i--)
        {

            dataModel.remove(ui->studentTableWidget->item(indexes.at(i-1).row(),0)->text());
            ui->studentTableWidget->removeRow(indexes.at(i-1).row());
        }
    }
}

void MainWindow::on_addDisciplineButton_clicked()
{
    if(dataModel.isEmpty())
    {
        QMessageBox::information(this,"Ошибка","Вы забыли добавить студента");

    }else
    {
        DisciplinesDialog disciplinesDialog;
        disciplinesDialog.addList(list);
        disciplinesDialog.setModal(true);
        disciplinesDialog.exec();

        if(!disciplinesDialog.name.isEmpty() and !disciplinesDialog.nameStudent.isEmpty() and !disciplinesDialog.date.isEmpty() and !disciplinesDialog.score.isEmpty())
        {
            Disciplines newDiscipline = Disciplines(disciplinesDialog.nameStudent, disciplinesDialog.name, disciplinesDialog.date,disciplinesDialog.score);

            dataModelDisciplines.insert(disciplinesDialog.nameStudent,newDiscipline);
            updateDisciplineTable();

        }
    }
}

void MainWindow::on_removeDisciplineButton_clicked()
{
    if(dataModelDisciplines.isEmpty())
        QMessageBox::information(this,"Ошибка","Список дисциплин пуст");
    else{
        QModelIndexList indexes =  ui->disciplineTableWidget->selectionModel()->selectedRows();
        int countRow = indexes.count();

        for (int i = countRow; i > 0; i--)
        {

            dataModelDisciplines.remove(ui->disciplineTableWidget->item(indexes.at(i-1).row(),0)->text());
            ui->disciplineTableWidget->removeRow(indexes.at(i-1).row());
        }
    }
}
