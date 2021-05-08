#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QMessageBox>
#include <QMap>
#include <QList>
#include <QDebug>
#include "studentdialog.h"
#include "disciplinesdialog.h"

class Disciplines
{
public:
    QString student;
    QString name;
    QString date;
    QString score;
    Disciplines();
    Disciplines(QString _student, QString _name,QString _date, QString _score)
    {
        student = _student;
        name = _name;
        date = _date;
        score = _score;
    }
};

class Student{

public:

    QString FIO;
    QString Group;
    QString Chipher;

    Student(QString _FIO, QString _chipher, QString _group)
    {
        FIO = _FIO;
        Group = _group;
        Chipher = _chipher;
    }

};



QT_BEGIN_NAMESPACE
namespace Ui { class MainWindow; }
QT_END_NAMESPACE



class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    QMap<QString, Student> dataModel;
    QMap<QString, Disciplines> dataModelDisciplines;
    QList<Student> list;
    void updateDisciplineTable();
    void updateStudentTable();
    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();

private slots:
    void on_addStudentButton_clicked();

    void on_removeStudentButton_clicked();

    void on_addDisciplineButton_clicked();

    void on_removeDisciplineButton_clicked();

private:
    Ui::MainWindow *ui;
};
#endif // MAINWINDOW_H
