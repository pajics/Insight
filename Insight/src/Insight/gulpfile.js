/// <vs BeforeBuild='fe-build' SolutionOpened='install' />
var gulp = require('gulp');
var install = require("gulp-install");
var p = require('gulp-load-plugins')({ camelize: true });
var fs = require('fs');
var bower = require('bower');
var browserify = require('gulp-browserify');
var path = require('path');
//var consolidate = require('gulp-consolidate');

var readPackage = function () {
  return JSON.parse(fs.readFileSync('./package.json', 'utf8'));
};

gulp.task('install', [], function () {
    gulp.src(['./package.json'])
        .pipe(install());
});

gulp.task('dev', function() {
  gulp.watch('src/BV.Web/Content/less/**.less', ['less']);
});

gulp.task('config', ['config-web'], function() {
});

gulp.task('bump-version', function() {
  return gulp.src('./package.json')
    .pipe(p.bump())
    .pipe(gulp.dest(''));
});

gulp.task('assembly-info', function() {
    var pkg = readPackage();

    var version = pkg.version + '.0';
    var company = 'DD';

    var assemblyVersion = '[assembly: AssemblyVersion("' + version + '")]'
    var assemblyFileVersion = '[assembly: AssemblyFileVersion("' + version + '")]'
    var assemblyCompany = '[assembly: AssemblyCompany("' + company + '")]';

    return gulp.src('**/AssemblyInfo.cs')
      .pipe(p.replace(/\[assembly: AssemblyVersion\(".*?"\)\]/gmi, assemblyVersion))
      .pipe(p.replace(/\[assembly: AssemblyFileVersion\(".*?"\)\]/gmi, assemblyFileVersion))
      .pipe(p.replace(/\[assembly: AssemblyCompany\(".*?"\)\]/gmi, assemblyCompany))
      .pipe(gulp.dest(''));
});

function dist(src) {
  var connectionStrings = fs.readFileSync('config/connectionstrings/' + src + '.config', 'utf-8');
  var smtpConfig = fs.readFileSync('config/smtp/' + src + '.config', 'utf-8');
  var appSettings = 'Config\\appsettings_' + src + '.config';
  var logSettings = 'config/nlog_' + src + '.config';

  return gulp.src('**/Web.config')
    .pipe(p.replace(/<connectionStrings>(.|\n|\r)*?<\/connectionStrings>/gmi, connectionStrings))
    .pipe(p.replace(/<mailSettings>(.|\n|\r)*?<\/mailSettings>/gmi, smtpConfig))
    .pipe(p.replace(/Config\\appsettings_.*\.config/gmi, appSettings))
    .pipe(p.replace(/config\/nlog_.*\.config/gmi, logSettings))
    .pipe(gulp.dest(''));
}

gulp.task('dist:local', ['disttask'], function() {
  return dist('local');
});

gulp.task('dist', ['distdev'], function() {

});

gulp.task('default', ['dev'], function() {

});


/*
 * Front-end Packages
 *
 * TASKS
 * fe: runs and watches all needed dev stuff. !!! needs to run "gulp fetch" once before first use !!!
 * fe-fetch: gets all bower components and copies needed files in right directories.
 *
 */

var packagesPath = './src/Insight/FrontEndPackages/';

var frontendPaths = {
    'less':         packagesPath + 'less/insight.less',
    'lessWatch':    packagesPath + 'less/**/*.less',
    'lessFolder':   packagesPath + 'less/',
    'app':          packagesPath + 'app/insightApp.js',
    'appFolder':    packagesPath + 'app/',
    'appWatch':     packagesPath + 'app/**/*.js',
    'icons':        packagesPath + 'icons/*.svg',
    'bower':        packagesPath + 'bower-components/',
    'templates':    packagesPath + 'app/templates/**/*html',

    'clean': [
                    packagesPath + 'bower-components',
                    packagesPath + 'less/bootstrap',
                    './src/Insight/wwwroot/fonts'
    ]
};

var webPaths = {
    'css': './src/Insight/wwwroot/css/',
    'js': './src/Insight/wwwroot/scripts/',
    'img': './src/Insight/wwwroot/images/',
    'fonts': './src/Insight/wwwroot/fonts/'
};

/* clean up */
gulp.task('clean', function () {
    return gulp.src(frontendPaths.clean, {read: false})
        .pipe(p.clean({force:true}));
});

/* fetch bower components */
gulp.task('bower', ['clean'], function(cb){
    bower.commands.install([], {save: true}, {})
        .on('end', function(installed){
        cb();
    });
});

/* copy vendor files as needed */
gulp.task('copy-vendor-scripts', ['bower'], function() {
    gulp.src([
        //frontendPaths.bower + 'modernizr/modernizr.min.js',
        frontendPaths.bower + 'angular/angular.min.js',
        frontendPaths.bower + 'angular/angular.min.js.map',
        //frontendPaths.bower + 'angular-route/angular-route.min.js',
        //frontendPaths.bower + 'angular-route/angular-route.min.js.map',
        //frontendPaths.bower + 'angular-animate/angular-animate.min.js',
        //frontendPaths.bower + 'angular-animate/angular-animate.min.js.map',
        //frontendPaths.bower + 'angular-cookies/angular-cookies.min.js',
        //frontendPaths.bower + 'angular-cookies/angular-cookies.min.js.map',
        frontendPaths.bower + 'jquery/jquery.min.js',
        frontendPaths.bower + 'jquery/jquery.min.map',
        frontendPaths.bower + 'bootstrap/dist/js/bootstrap.min.js',
        //frontendPaths.bower + 'angular-strap/dist/angular-strap.min.js',
        //frontendPaths.bower + 'angular-strap/dist/angular-strap.min.js.map',
        //frontendPaths.bower + 'angular-strap/dist/angular-strap.tpl.min.js',
        //frontendPaths.bower + 'angular-strap/dist/angular-strap.tpl.min.js',
        //frontendPaths.bower + 'modernizr/modernizr.js'
    ])
        .pipe(gulp.dest(webPaths.js));
});

gulp.task('copy-vendor-fonts', ['bower'], function () {
    gulp.src(frontendPaths.bower + 'components-font-awesome/fonts/fontawesome-webfont.*')
        .pipe(gulp.dest(webPaths.fonts));
});

gulp.task('copy-bs-less', ['bower'],  function() {
     return gulp.src(frontendPaths.bower + 'bootstrap/less/**/*')
            .pipe(gulp.dest(frontendPaths.lessFolder + 'bootstrap/'));
});

gulp.task('copy-fa-less', ['bower'], function () {
    return gulp.src(frontendPaths.bower + 'components-font-awesome/less/*')
            .pipe(gulp.dest(frontendPaths.lessFolder + 'fontawesome/'));
});


/* styles */
gulp.task('less', function () {
    gulp.src(frontendPaths.less)
        .pipe(p.plumber())
        .pipe(p.lessSourcemap({
            generateSourceMap: true
        }))
        .pipe(gulp.dest(webPaths.css));
});

gulp.task('less-build', ['copy-fa-less', 'copy-bs-less'], function () {
    gulp.src(frontendPaths.less)
        .pipe(p.plumber())
        .pipe(p.lessSourcemap({
            generateSourceMap: true
        }))
        .pipe(p.minifyCss())
        .pipe(gulp.dest(webPaths.css));
});


/* javascript/angular */
gulp.task('app-templates', function() {
    var stream = gulp.src(frontendPaths.templates)
        .pipe(p.angularTemplatecache('insight-templates.js', {
            module: 'insightApp'
        }))
        .pipe(gulp.dest(frontendPaths.appFolder));
    return stream;
});

gulp.task('app-build', ['app-templates'], function() {
    gulp.src(frontendPaths.app)
        .pipe(browserify({
            insertGlobals : true,
            debug : !gulp.env.production
        }))
        .pipe(gulp.dest(webPaths.js))
});

/* watch stuff */
gulp.task('watch', function () {
    gulp.watch(frontendPaths.lessWatch, ['less']);
    gulp.watch(frontendPaths.appWatch, ['app-build']);
    gulp.watch(frontendPaths.templates, ['app-build']);
});


/* end user tasks */
gulp.task('fe-fetch', ['clean', 'bower', 'copy-bs-less', 'copy-vendor-scripts', 'copy-vendor-fonts']);
gulp.task('fe', ['less', 'app-templates', 'app-build', 'watch']);
gulp.task('fe-build', ['clean', 'bower', 'copy-fa-less', 'copy-bs-less', 'copy-vendor-scripts', 'copy-vendor-fonts', 'less-build', 'app-templates', 'app-build']);
