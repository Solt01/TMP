#ifndef DISCIPLINESDIALOG_H
#define DISCIPLINESDIALOG_H

#include <QDialog>
#include <QMessageBox>
#include <QList>
class Student;
namespace Ui {
class DisciplinesDialog;
}

class DisciplinesDialog : public QDialog
{
    Q_OBJECT

public:
    QString nameStudent;
    QString name;
    QString date;
    QString score;

    QList<Student> list;
    void addList(QList<Student> _list);
    explicit DisciplinesDialog(QWidget *parent = nullptr);
    ~DisciplinesDialog();

private slots:
    void on_pushButton_clicked();

private:
    Ui::DisciplinesDialog *ui;
};

#endif // DISCIPLINESDIALOG_H
