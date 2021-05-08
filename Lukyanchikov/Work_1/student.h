#ifndef STUDENT_H
#define STUDENT_H

#include <QDialog>
#include <QMessageBox>

namespace Ui {
class WindowStudent;
}

class WindowStudent : public QDialog
{
    Q_OBJECT

public:
    QString FIO;
    QString Chipher;
    QString Group;
    explicit WindowStudent(QWidget *parent = nullptr);
    ~WindowStudent();

private slots:
    void on_pushButton_clicked();

private:
    Ui::WindowStudent *ui;
};

#endif // STUDENT_H
