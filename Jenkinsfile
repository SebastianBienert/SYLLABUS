pipeline {
    agent any
    stages{
        stage('Clean') {
            steps {
                sh 'dotnet clean'
                echo 'clean done'
            }
        }
        stage('Build') {
            steps {
                sh 'dotnet build --configuration release'
                echo 'build done'
            }
        }
        stage('Test') {
            steps {
                sh 'dotnet test'
                echo 'test done'
            }
        }
        // stage('Docker-build') {
        //     steps {
        //         sh 'docker-compose build'
        //         echo 'Container build done'
        //     }
        // }
    }
}